using Application.Dto;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailDTO emailDto);
    }
}
