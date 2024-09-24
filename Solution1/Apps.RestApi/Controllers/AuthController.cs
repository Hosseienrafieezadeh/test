using Apps.Services.ApplicationUsers.Contracts.Dtos;
using Apps.Services.ApplicationUsers.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apps.RestApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // Route For Seeding my roles to DB
        [HttpPost("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seerRoles = await _authService.SeedRolesAsync();
            return Ok(seerRoles);
        }

        // Route -> Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = await _authService.RegisterAsync(registerDto);
            if (registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);
        }

        // Route -> Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var loginResult = await _authService.LoginAsync(loginDto);
            if (loginResult.IsSucceed)
                return Ok(loginResult);

            return Unauthorized(loginResult);
        }

        // Route -> make user -> admin
        [HttpPost("make-admin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _authService.MakeAdminAsync(updatePermissionDto);
            if (operationResult.IsSucceed)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }

        // Route -> make user -> owner
        [HttpPost("make-owner")]
        public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _authService.MakeOwnerAsync(updatePermissionDto);
            if (operationResult.IsSucceed)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }

        // Route -> Get user by username
        [HttpGet("get-user/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _authService.GetUserByIdAsync(userName);  // Assuming this method exists
            if (user == null)
                return NotFound(new { Message = "User not found" });

            return Ok(user);
        }

        // Route -> Update user details
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var updateResult = await _authService.UpdateUserAsync(updateUserDto);
            if (updateResult.IsSucceed)
                return Ok(updateResult);

            return BadRequest(updateResult);
        }

        // Route -> Delete user by username
        [HttpDelete("delete-user/{userName}")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            var deleteResult = await _authService.DeleteUserAsync(userName);
            if (deleteResult.IsSucceed)
                return Ok(deleteResult);

            return BadRequest(deleteResult);
        }
    }
}
