using Application.Dto;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IRolOptionsRepository
    {
        Task<MenuResponseDTO> GetListRolOptions(int rol); 
    }
}
