using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureDevelopment.Model;
using SecureDevelopment.Repository;

namespace SecureDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IRepositoryUser _repositoryUser;

        public UserController(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
        
        [Authorize(Roles = "Administrator,User"), HttpPost("AddUser")] 
        public IActionResult AddUser([FromBody] UserAccount user)
        {
            var result = -1;
            
            if (_repositoryUser.GetIdUserByName(user.Login)!=0) return Ok(-2); //если юзер уже есть в базе
            if (string.IsNullOrWhiteSpace(user.Login) || 
                string.IsNullOrWhiteSpace(user.Password) || 
                user.Role is not "Administrator" or "User") return Ok(-3); //если невалидные поля
            
            result = _repositoryUser.Add(user);
            
            return Ok(result);
        }

        [Authorize(Roles = "Administrator,User"), HttpPost("GetUser")]
        public IActionResult GetUserId([FromBody] UserAccount user)
        {
            var result = _repositoryUser.GetUser(user);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator,User"), HttpPut("updateUser")]
        public IActionResult UpdateUser([FromBody] UserAccount user)
        {
            var result = _repositoryUser.Update(user);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator"), HttpDelete("delete")]
        public IActionResult DeleteUser([FromQuery] int id)
        {
            var result = _repositoryUser.Delete(id);
            return Ok(result);
        }
    }
}