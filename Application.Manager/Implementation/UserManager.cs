using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.MaintenanceUser;
using Application.Dto.Usuario;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserManager(IUserService userService,
            IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<CustomerDTO> RegisterCustomerUser(CustomerUserDTO customerUsuarioDTO)
        {
            UsuarioEntity usuarioEntity = mapper.Map<UsuarioEntity>(customerUsuarioDTO);
            UsuarioEntity _usuarioEntity = await userService.RegisterCustomerUser(usuarioEntity);
            CustomerDTO customerDTO = mapper.Map<CustomerDTO>(_usuarioEntity);
            return customerDTO;
        }

        public async Task<UserDTO> AddAsync(UserRequestDTO userRequestDto)
        {
            UsuarioEntity user = mapper.Map<UsuarioEntity>(userRequestDto);
            UsuarioEntity userEntity = await userService.AddAsync(user);
            UserDTO userDTO = mapper.Map<UserDTO>(userEntity);
            return userDTO;
        }

        public async Task<bool> UpdateAsync(UserDTO userDto)
        { 
            var result = await userService.UpdateAsync(userDto);
            return result;
        }

        public async Task<int> DeleteUserMaintence(int idUsuario, int idUsuarioLog)
        {
            var result = await userService.DeleteUserMaintence(idUsuario, idUsuarioLog);
            return result;
        }

        public async Task<bool> DeleteAsync(int idUsuario, int idUsuarioLog)
        {
            var result = await userService.DeleteAsync(idUsuario, idUsuarioLog);
            return result;
        }

        public async Task<List<UserDTO>> SelectAsync(int idUsuario)
        {
            var result = await userService.SelectAsync(idUsuario);
            return result;
        }
        public async Task<TotalListUserEntity> ListUserMaintence(ListUserFilterDTO request)
        {
            var result = await userService.ListUserMaintence(request);
            return result;
        }
        public async Task<TotalListUserEntity> ListUserEstadoMaintence(ListUserEstadoFilterDTO request)
        {
            var result = await userService.ListUserEstadoMaintence(request);
            return result;
        }

        public PagedList<UsuarioTempEntity> ListAsync(FilterUserDTO filterUserDTO)
        {
            var page = userService.ListAsync(filterUserDTO);
            return page;
        }

        public async Task<List<UsuarioEntity>> ValidateUsuario(string emailUsuario)
        {
            var result = await userService.ValidateUsuario(emailUsuario);
            return result;
        }
        public async Task<UsuarioEntity> ValidarEstadoUsuario(string usuarioemail)
        {
            return await userService.ValidarEstadoUsuario(usuarioemail);
        }
        public async Task<ConsultaUsuarioEntity> ConsultaDatosUsuario(int idUsuario)
        {
            var result = await userService.ConsultaDatosUsuario(idUsuario);
            return result;
        }

        public async Task<ConsultaDatosAdicionalesUsuarioEntity> ConsultaDatosAdicionalesUsuarioById(int idUsuario, int IdPreevaluacion)
        {
            var result = await userService.ConsultaDatosAdicionalesUsuarioById(idUsuario, IdPreevaluacion);
            return result;
        }

        public async Task<bool> UserRecordDatosAdicionales(UserDataAdditionalRequestDTO userRequestDTO)
        {
            var result = await userService.UserRecordDatosAdicionales(userRequestDTO);
            return result;
        }
    }
}
