using ReadCity.Api.Dtos;
using ReadCity.DataAccess.Models;
using ReadCity.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace ReadCity.Api.Controllers
{
    /// <summary>
    /// API авторизации пользователей.
    /// </summary>
    /// <param name="authService"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost("login")]
        public ActionResult<User> Login(LoginRequest request)
        {
            var user = _authService.Login(request.Login, request.Password);
            return user is null ? Unauthorized("Неверный логин или пароль.") : Ok(user);
        }
    }
}
