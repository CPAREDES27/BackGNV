using Application.Dto;
using Application.Dto.Security;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<RolMenuDTO> RolMenu_Padre(int rol)
        {
            return await _unitOfWork.SecurityRepository.RolMenu_Padre(rol);
        }
        public async Task<List<RolMenuHijoDTO>> RolMenu_Hijo(int rolId, int idMenuPadre)
        {
            return await _unitOfWork.SecurityRepository.RolMenu_Hijo(rolId, idMenuPadre);
        }
        public async Task<MenuResponseDTO> GetListRolOptions(int rol)
        {
            return await _unitOfWork.SecurityRepository.GetListRolOptions(rol);
        }

        public async Task<UsuarioEntity> GetLoginCredentials(UserLoginDTO userLogin)
        {
            return await _unitOfWork.SecurityRepository.GetLoginCredentials(userLogin);
        } 
    }
}
