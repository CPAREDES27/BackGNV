using Application.Dto;
using Domain.MainModule.Entities;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ISecurityRepository
    {
        Task<MenuResponseDTO> GetListRolOptions(int rol);
        Task<UsuarioEntity> GetLoginCredentials(UserLoginDTO userLogin);
    }
}
