using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailManager _emailManager;
        private readonly ILogger<EmailController> _logger;

        public EmailController(
            IEmailManager emailManager,
            ILogger<EmailController> logger)
        {
            this._emailManager = emailManager;
            this._logger = logger;
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] EmailDTO emailDTO)
        {
            bool result = await _emailManager.SendEmailAsync(emailDTO);

            if (!result)
            {
                return BadRequest(new { valid = false, message = EmailConst.ErrorSendEmail });
            }

            return Ok(new { valid = true, message = EmailConst.SuccessSendEmail });
        }
    }
}
