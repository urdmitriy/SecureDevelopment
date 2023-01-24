using Microsoft.AspNetCore.Mvc;
using SecureDevelopment.Model;
using SecureDevelopment.Services;

namespace SecureDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IAuthorization _authorization;

        public LoginController(IAuthorization authorization)
        {
            _authorization = authorization;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserAccount user)
        {
            var result = _authorization.GetTokenKey(user);
            return Ok(result);
        }
    }
}