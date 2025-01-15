namespace FHS.Api.Controllers.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    //TEST
    private readonly Dictionary<string, string> _users = new Dictionary<string, string>
    {
        { "admin", "password123" },
        { "user", "userpassword" }
    };

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest("Brak nazwy użytkownika lub hasła.");
        }

        if (_users.TryGetValue(request.Username, out var password) && password == request.Password)
        {
            var token = GenerateFakeToken(request.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized("Nieprawidłowa nazwa użytkownika lub hasło.");
    }

    private string GenerateFakeToken(string username)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{DateTime.UtcNow}"));
    }
}
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
