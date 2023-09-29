using CepCSharp_API.Entities.Records;
using CepCSharp_API.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CepCSharp_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCart([FromBody] UserRecord user)
        {
            try
            {
                var userId = await _userService.CreateUser(user);
                return Ok($"Id: {userId}");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }
    }
}
