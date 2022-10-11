using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.MaintenanceUser;
using Application.Dto.Usuario;
using Application.Manager.Interfaces;
using Application.Services.Util;
using AutoMapper;
using Domain.MainModule.Entities;
using Infrastructure.MainModule.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public UserController(IUserManager userManager,
            IMapper mapper, IUriService uriService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        [HttpPost("CustomerRegister")]
        public async Task<IActionResult> CustomerRegister([FromBody] CustomerUserDTO customerUsuarioDTO)
        {
            //Encriptar Contraseña
            customerUsuarioDTO.Contrasena = CryptoHelper.EncryptAES(customerUsuarioDTO.Contrasena);

            var resultadoUsuario = await userManager.ValidateUsuario(customerUsuarioDTO.UsuarioEmail);

            if (resultadoUsuario.Count > 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidEmailUsuario });
            }
            else
            {
                CustomerDTO customerDTO = await userManager.RegisterCustomerUser(customerUsuarioDTO);

                if (customerDTO.IdUsuario < 0)
                {
                    return BadRequest(new { valid = false, messaje = Constants.ResponseCustomerRegister });
                }

                return Ok(new { valid = true, message = Constants.ReponseAddAsync });
            }
        }

        [HttpPost("UserRecordMaintenance")]
        public async Task<IActionResult> UserRecordMaintenance([FromBody] UserRequestDTO userRequestDTO)
        {
            userRequestDTO.Contrasena = CryptoHelper.EncryptAES(userRequestDTO.Contrasena);

            UserDTO userDto = await userManager.AddAsync(userRequestDTO);
            if (userDto.IdUsuario < 0)
            {
                return BadRequest(new { valid = false, messaje = Constants.InvalidResponseAddAsync });
            }
            return Ok(new { valid = true, message = Constants.ReponseAddAsync });
        }

        [HttpPost("UserUpdateMaintenance")]
        public async Task<IActionResult> UserUpdateMaintenance([FromBody] UserDTO userDto)
        {
            userDto.Contrasena = CryptoHelper.EncryptAES(userDto.Contrasena);

            var resultadoUsuario = await userManager.ValidateUsuario(userDto.UsuarioEmail);

            bool existeUsuarioEmail = resultadoUsuario.Any(x => x.IdUsuario != userDto.IdUsuario);

            if (existeUsuarioEmail)
            {
                return Ok(new { valid = false, message = Constants.InvalidEmailUsuario });
            }

            var usertDto = await userManager.UpdateAsync(userDto);

            if (!usertDto)
            {
                return BadRequest(new { valid = false, messaje = Constants.ReponseInvalidUpdateUser });
            }

            return Ok(new { valid = true, message = Constants.ReponseUpdateUser });
        }

        
       [HttpGet("UserDeleteMaintenance_homo")]
        public async Task<IActionResult> DeleteUserMaintence(int idUsuario, int idUsuarioLog)
        {
            var resultado = await userManager.DeleteUserMaintence(idUsuario, idUsuarioLog);
            if (resultado <= 0)
            {
                return BadRequest(new { valid = false, messaje = Constants.ReponseInvalidDeleteUser });
            }
            return Ok(new { valid = true, message = Constants.ReponseDeleteUser });
        }


        [HttpPost("UserDeleteMaintenance")]
        public async Task<IActionResult> UserDeleteMaintenance(int idUsuario, int idUsuarioLog)
        {
            var usertDto = await userManager.DeleteAsync(idUsuario, idUsuarioLog);
            if (!usertDto)
            {
                return BadRequest(new { valid = false, messaje = Constants.ReponseInvalidDeleteUser });
            }
            return Ok(new { valid = true, message = Constants.ReponseDeleteUser });
        }

        [HttpGet("SelectMaintenanceUser")]
        public async Task<IActionResult> SelectMaintenanceUser(int idUsuario)
        {
            List<UserDTO> usertDto = await userManager.SelectAsync(idUsuario);
            if (usertDto.Count < 0)
            {
                return BadRequest(new { valid = false, messaje = Constants.ReponseInvalidIdUser });
            }
            return Ok(usertDto);
        }

        
        [HttpPost("UserListMaintenance_homo")]
        public async Task<IActionResult> ListUserMaintence(ListUserFilterDTO request)
        {
            var resultado =  await userManager.ListUserMaintence(request);
            if (resultado == null)
            {
                return BadRequest(new { valid = false, messaje = Constants.InvalidListUserMaintence });
            }
            return Ok(resultado);

        }


        [HttpPost("UserListEstadoMaintenance")]
        public async Task<IActionResult> ListUserEstadoMaintence(ListUserEstadoFilterDTO request)
        {
            var resultado = await userManager.ListUserEstadoMaintence(request);
            if (resultado == null)
            {
                return BadRequest(new { valid = false, messaje = Constants.InvalidListUserMaintence });
            }
            return Ok(resultado);

        }


        [HttpGet("UserListMaintenance")]
        public IActionResult UserListPagination([FromQuery] FilterUserDTO filterUserDTO)
        {
            var usuarioEntities = userManager.ListAsync(filterUserDTO);
            var resultUserDtos = mapper.Map<List<UserPageResponseDTO>>(usuarioEntities);
            var metaData = new MetaData
            {
                TotalCount = usuarioEntities.TotalCount,
                PageSize = usuarioEntities.PageSize,
                CurrentPage = usuarioEntities.CurrentPage,
                TotalPages = usuarioEntities.TotalPages,
                HasNextPage = usuarioEntities.HasNextPage,
                HasPreviousPage = usuarioEntities.HasPreviousPage,
                NextPageUrl = uriService.GetPostPaginationUserUri(filterUserDTO, Url.RouteUrl(RouteData.Values)).ToString(),
                PreviousPageUrl = uriService.GetPostPaginationUserUri(filterUserDTO, Url.RouteUrl(RouteData.Values)).ToString()
            };

            var response = new ApiResponse<List<UserPageResponseDTO>>(resultUserDtos)
            {
                Meta = metaData
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
            return Ok(response);

        }
        [HttpGet("ValidarUsuarioEstado")]
        public async Task<IActionResult> ValidarEstadoUsuario(string usuarioemail)
        {
            UsuarioEntity resultValidarUsuario = await userManager.ValidarEstadoUsuario(usuarioemail);

            if (resultValidarUsuario == null)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidValidarEstadoUsuario });
            }

            return Ok(resultValidarUsuario);
        }

        [HttpGet("ConsultaDatosUsuario")]
        public async Task<IActionResult> ConsultaDatosUsuario(int idUsuario)
        {
            ConsultaUsuarioEntity resultValidarUsuario = await userManager.ConsultaDatosUsuario(idUsuario);

            if (resultValidarUsuario == null)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidConsultaDatosUsuario });
            }

            return Ok(resultValidarUsuario);
        }

        [HttpGet("ConsultaDatosAdicionalesUsuarioById")]
        public async Task<IActionResult> ConsultaDatosAdicionalesUsuarioById(int idUsuario,int IdPreevaluacion)
        {
            ConsultaDatosAdicionalesUsuarioEntity resultDatosAdicionalesValidarUsuario = await userManager.ConsultaDatosAdicionalesUsuarioById(idUsuario, IdPreevaluacion);

            if (resultDatosAdicionalesValidarUsuario == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidConsultaDatosAdicionalesUsuario });
            }

            return Ok(resultDatosAdicionalesValidarUsuario);

        }

        [HttpPost("UserRecordDatosAdicionales")]
        public async Task<IActionResult> UserRecordDatosAdicionales([FromBody] UserDataAdditionalRequestDTO userRequestDTO)
        {
            var usertDto = await userManager.UserRecordDatosAdicionales(userRequestDTO);
            if (!usertDto)
            {
                return Ok(new { valid = false, messaje = Constants.ReponseInvalidDatosAdicionalesUser });
            }
            return Ok(new { valid = true, message = Constants.ReponseDatosAdicionalesUser });
        }

    }
}
