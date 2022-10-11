using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{ 
    //[Authorize]
    [ApiController]
    [EnableCors("SoloAngular")]
    [Route("api/[controller]")] 
    public class AuthController : ControllerBase
    {
        private readonly ISecurityManager securityManager;

        public AuthController(
            ISecurityManager securityManager
            )
        {
            this.securityManager = securityManager;
        }

        [HttpPost("UserAuthentication")]
        public async Task<IActionResult> UserAuthentication(UserLoginDTO userLogin)
        {
            userLogin.Password = CryptoHelper.EncryptAES(userLogin.Password);

            LoginResponseDTO usuarioEntity = await securityManager.GetLoginCredentials(userLogin);

            if (usuarioEntity == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidUser });
            }
            else
            {
                return Ok(usuarioEntity);
            }
        }
    }
}
