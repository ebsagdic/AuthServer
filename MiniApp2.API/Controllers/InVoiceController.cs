using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MiniApp2.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InVoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            //Istek yapılan tokenın payloadından okunur.
            var userName = HttpContext.User.Identity.Name;

            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);


            //Db işlemleri yapabilirsin ben uğraşmıyorum
            return Ok($"Invoice işlemleri => UserName{userName}, userID =>{userIdClaim.Value}");
        }
    }
}
