using DesafioUbc.Application.Requests.User;
using DesafioUbc.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioUbc.Api.Controllers;

[Route("api/auth")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var response = _userService.Login(request, _configuration["Jwt:Key"]);

        if (response.Data is null) return BadRequest(response);

        return Ok(response);
    }
}