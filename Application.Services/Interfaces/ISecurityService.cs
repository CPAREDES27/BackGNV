using Application.Dto;
using Application.Dto.Security;
using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<UsuarioEntity> GetLoginCredentials(UserLoginDTO usuarioEntity);
        Task<RolMenuDTO> RolMenu_Padre(int rol);
        Task<List<RolMenuHijoDTO>> RolMenu_Hijo(int rolId, int idMenuPadre);
        Task<MenuResponseDTO> GetListRolOptions(int rol);
    }
}
