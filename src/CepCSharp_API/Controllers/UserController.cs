using CepCSharp_API.Entities.DTOs;
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

        [HttpPut]
        [Route("Update/{id}")]
        //[Authorize]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UserRecord user)
        {
            try
            {
                await _userService.UpdateUser(user, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            try
            {
                var result = await _userService.GetUserById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var result = await _userService.GetUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRecord user)
        {
            try
            {
                var token = await _userService.Login(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message.ToString() });
            }
        }
    }
}
