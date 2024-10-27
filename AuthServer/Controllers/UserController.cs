using AuthServer.Core.DTO_s;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            //HttpContext.User.Identity.Name ifadesi kullanılıyor.
            //Bu yapı, kullanıcı kimlik doğrulaması yapmış olduğunda kullanıcı adını almak için kullanılır.
            //HttpContext.User: ASP.NET Core'un sunduğu bu nesne,
            //şu anda kimliği doğrulanmış kullanıcıya ait ClaimsPrincipal nesnesini içerir ve
            //JWT token veya cookie gibi kimlik doğrulama mekanizmaları kullanılarak
            //kimliği doğrulanmış kullanıcının bilgilerine erişim sağlar.
            return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
    }
}
