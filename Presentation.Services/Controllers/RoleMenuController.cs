using Application.Dto.Security;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleMenuController : ControllerBase
    {
        private readonly ISecurityManager securityManager;

        public RoleMenuController(
           ISecurityManager securityManager
           )
        {
            this.securityManager = securityManager;
        }
       
        [HttpGet("GetListMenuOpciones_homo")]
         public async Task<IActionResult> RolMenu_Padre_Hijo(int rol)
        {
            var  resultado = await securityManager.RolMenu_Padre_Hijo(rol);
            if (resultado.menus.menusPadre.Count <=  0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidRolMenuPadre_Hijo });
            }
            return Ok(resultado);
        }

        [HttpGet("GetListMenuOpciones")]
        public async Task<IActionResult> GetAllRolOptions(int rol)
        {
            return Ok(await securityManager.GetListRolOptions(rol));
        } 
    }
}
