using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Services;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userService.Add(user);

            return Ok("User created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            var existingUser = _userService.GetById(id);

            if (existingUser == null)
                return NotFound();

            _userService.Update(id, user);

            return Ok("User updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            _userService.Delete(id);

            return Ok("User deleted successfully");
        }
    }
}
