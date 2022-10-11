using Application.Dto;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IEmailManager
    {
        Task<bool> SendEmailAsync(EmailDTO emailDto);
    }
}
