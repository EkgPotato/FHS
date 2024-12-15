namespace FHS.Api.Controllers.Auth
{
    using Microsoft.AspNetCore.Identity.Data;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        // Tymczasowa lista użytkowników dla demonstracji
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

            // Sprawdzenie poprawności danych logowania
            if (_users.TryGetValue(request.Username, out var password) && password == request.Password)
            {
                // Wygenerowanie przykładowego tokena (zastąp prawdziwym JWT w produkcji)
                var token = GenerateFakeToken(request.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Nieprawidłowa nazwa użytkownika lub hasło.");
        }

        // Metoda do generowania fikcyjnego tokena
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
}
