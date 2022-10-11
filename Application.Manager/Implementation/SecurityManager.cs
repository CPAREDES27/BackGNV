using Application.Dto;
using Application.Dto.Security;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using Infrastructure.MainModule.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class SecurityManager : ISecurityManager
    {
        private readonly ISecurityService securityService;
        private readonly IMapper mapper;
        private readonly IPasswordService passwordService;
        private readonly IConfiguration configuration;

        public SecurityManager(
             ISecurityService securityService,
             IMapper mapper,
             IPasswordService passwordService,
             IConfiguration configuration
            )
        {
            this.securityService = securityService;
            this.mapper = mapper;
            this.passwordService = passwordService;
            this.configuration = configuration;
        }

        public async Task<LoginResponseDTO> GenerateToken(UsuarioDTO userMap)
        {
            LoginResponseDTO response = null;
            //Header 
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            var razonSocial = string.Empty;
            var nomCli = string.Empty;
            var apeCli = string.Empty;

            if (userMap == null) { return null; } 
            if (userMap.NomCliente == null || userMap.ApeCliente == null) { nomCli = "ninguno"; apeCli = "ninguno"; }
            else { nomCli = userMap.NomCliente; apeCli = userMap.ApeCliente; } 
            if (userMap.RazonSocial == null) { razonSocial = "ninguno"; }
            else { razonSocial = userMap.RazonSocial; }

            //add Claims
            var claims = new[]
            {
                new Claim("id", userMap.IdUsuario.ToString()),
                new Claim("usuario", userMap.UsuarioEmail),
                new Claim("nombres", nomCli),
                new Claim("apellidos", apeCli),
                new Claim("razonSocial", razonSocial), 
                new Claim("rol", userMap.RolId.ToString())
            };

            //Payload
            var payload = new JwtPayload
            (
               configuration["Authentication:Issuer"],
               configuration["Authentication:Audience"],
               claims,
               DateTime.Now,
               expires: DateTime.Now.AddMinutes(5),
               DateTime.UtcNow.AddMinutes(5)
            );

            var token = new JwtSecurityToken(header, payload);
            string tkResponse = new JwtSecurityTokenHandler().WriteToken(token);

            response = new LoginResponseDTO
            {
                Codigo = userMap.IdUsuario,
                Token = tkResponse
            };

            return response;
        }

        public async Task<MenuGeneral> RolMenu_Padre_Hijo(int rol)
        {
            {
                var menus = await securityService.RolMenu_Padre(rol);
                var response = new MenuGeneral();
                var responseDTO = new RolMenuDTO();

                foreach (var item in menus.menusPadre)
                {
                    var menusPadre = new MenuPadres();
                    menusPadre.IdPadre = item.IdPadre;
                    menusPadre.DescMenu = item.DescMenu;
                    menusPadre.UrlImagen = item.UrlImagen;
                    menusPadre.RolId = item.RolId;

                    var details = await securityService.RolMenu_Hijo(item.RolId,item.IdPadre);
                    menusPadre.menusHijos = new List<MenuRolHijo>();
                    foreach (var detail in details)
                    {
                        var detailitem = new MenuRolHijo();
                        detailitem.IdPadre = detail.IdMenuPadre;
                        detailitem.IdMenuHijo = detail.IdMenuHijo;
                        detailitem.IdOpcion = detail.IdOpcion;
                        detailitem.DescMenu = detail.DescMenu;
                        detailitem.Url = detail.Url;
                        detailitem.Activo = detail.Activo;
                        menusPadre.menusHijos.Add(detailitem);
                    }
                    responseDTO.menusPadre.Add(menusPadre);

                }
                response.menus = new RolMenuDTO();
                response.menus = responseDTO;
                return response;
            }
        }

        public async Task<MenuResponseDTO> GetListRolOptions(int rol)
        {
            MenuResponseDTO menuDTO = await securityService.GetListRolOptions(rol); 
            return menuDTO; 
        } 

        public async Task<LoginResponseDTO> GetLoginCredentials(UserLoginDTO userLogin)
        {
            var user = await securityService.GetLoginCredentials(userLogin);
            UsuarioDTO userMap = mapper.Map<UsuarioDTO>(user);
            LoginResponseDTO response = await GenerateToken(userMap);
            return response;
        }

        public async Task<(bool, UsuarioEntity)> IsValidateUser(UserLoginDTO userLogin)
        {
            UsuarioEntity user = await securityService.GetLoginCredentials(userLogin);
            var isValid = passwordService.Check(user.Contrasena, userLogin.Password);
            return (isValid, user);
        }
    }
}