using Application.Dto.Usuario;
using Application.Dto.CustomEntities;
using Application.Dto.MaintenanceUser;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        } 

        public async Task<UsuarioEntity> RegisterCustomerUser(UsuarioEntity usuarioEntity)
        {
            return await _unitOfWork.userRepository.RegisterCustomerUser(usuarioEntity);
        }

        public async Task<UsuarioEntity> AddAsync(UsuarioEntity user)
        {
            return await _unitOfWork.userRepository.AddAsync(user);
        }

        public async Task<bool> UpdateAsync(UserDTO userDto)
        {
            return await _unitOfWork.userRepository.UpdateAsync(userDto);
        }
        public async Task<int> DeleteUserMaintence(int idUsuario, int idUsuarioLog)
        {
            var result = await _unitOfWork.userRepository.DeleteUserMaintence(idUsuario, idUsuarioLog);
            return result;
        }
        public async Task<bool> DeleteAsync(int idUsuario, int idUsuarioLog)
        {
            return await _unitOfWork.userRepository.DeleteAsync(idUsuario, idUsuarioLog);
        }

        public async Task<List<UserDTO>> SelectAsync(int idUsuario)
        {
            return await _unitOfWork.userRepository.SelectAsync(idUsuario);
        }
        public async Task<TotalListUserEntity> ListUserMaintence(ListUserFilterDTO request)
        {
            var result = await _unitOfWork.userRepository.ListUserMaintence(request);
            return result;
        }

        public async Task<TotalListUserEntity> ListUserEstadoMaintence(ListUserEstadoFilterDTO request)
        {
            var result = await _unitOfWork.userRepository.ListUserEstadoMaintence(request);
            return result;
        }
        public PagedList<UsuarioTempEntity> ListAsync(FilterUserDTO filterUserDTO)
        {
            return _unitOfWork.userRepository.ListAsync(filterUserDTO);
        }

        public async Task<List<UsuarioEntity>> ValidateUsuario(string emailUsuario)
        {
            var result = await _unitOfWork.userRepository.ValidateUsuario(emailUsuario);
            return result;
        }
        public async Task<UsuarioEntity> ValidarEstadoUsuario(string usuarioemail)
        {
            return await _unitOfWork.userRepository.ValidarEstadoUsuario(usuarioemail);
        }
        public async Task<ConsultaUsuarioEntity> ConsultaDatosUsuario(int idUsuario)
        {
            var result = await _unitOfWork.userRepository.ConsultaDatosUsuario(idUsuario);
            return result;
        }

        public async Task<ConsultaDatosAdicionalesUsuarioEntity> ConsultaDatosAdicionalesUsuarioById(int idUsuario, int IdPreevaluacion)
        {
            var result = await _unitOfWork.userRepository.ConsultaDatosAdicionalesUsuarioById(idUsuario, IdPreevaluacion);
                return result;
        }

        public async Task<bool> UserRecordDatosAdicionales(UserDataAdditionalRequestDTO userRequestDTO)
        {
            return await _unitOfWork.userRepository.UserRecordDatosAdicionales(userRequestDTO);
        }
    }
}
