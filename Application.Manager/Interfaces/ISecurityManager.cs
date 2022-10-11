using Application.Dto;
using Application.Dto.Security;
using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface ISecurityManager
    { 
        Task<(bool, UsuarioEntity)> IsValidateUser(UserLoginDTO userLogin);
        Task<MenuGeneral> RolMenu_Padre_Hijo(int rol);
        Task<MenuResponseDTO> GetListRolOptions(int rol);
        Task<LoginResponseDTO> GetLoginCredentials(UserLoginDTO userLogin);
    } 
}
