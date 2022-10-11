﻿using Application.Dto.Usuario;
using Application.Dto.CustomEntities;
using Application.Dto.MaintenanceUser;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UsuarioEntity> RegisterCustomerUser(UsuarioEntity usuarioEntity);

        Task<UsuarioEntity> AddAsync(UsuarioEntity user);

        Task<bool> UpdateAsync(UserDTO userDto);
        Task<int> DeleteUserMaintence(int idUsuario, int idUsuarioLog);
        Task<bool> DeleteAsync(int idUsuario, int idUsuarioLog);

        Task<List<UserDTO>> SelectAsync(int idUsuario);
        Task<TotalListUserEntity> ListUserMaintence(ListUserFilterDTO request);

        Task<TotalListUserEntity> ListUserEstadoMaintence(ListUserEstadoFilterDTO request);

        PagedList<UsuarioTempEntity> ListAsync(FilterUserDTO filterUserDTO);

        Task<List<UsuarioEntity>> ValidateUsuario(string emailUsuario);
        Task<UsuarioEntity> ValidarEstadoUsuario(string usuarioemail);
        Task<ConsultaUsuarioEntity> ConsultaDatosUsuario(int idUsuario);

        Task<ConsultaDatosAdicionalesUsuarioEntity> ConsultaDatosAdicionalesUsuarioById(int idUsuario,int IdPreevaluacion);

        Task<bool> UserRecordDatosAdicionales(UserDataAdditionalRequestDTO userRequestDTO);
    }
}
