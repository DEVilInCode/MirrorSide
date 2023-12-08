using Microsoft.AspNetCore.Mvc;
using Server.Services;
using SharedLibrary.Requests;
using SharedLibrary.Responses;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AuthenticationRequest request)
    {
        var (success, content) = await _authService.RegisterAsync(request.Username, request.Password);
        if(!success) return BadRequest(content);

        return await Login(request);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticationRequest request)
    {
        var (success, content) = await _authService.LoginAsync(request.Username, request.Password);
        if(!success) return BadRequest(content);

        return Ok(new AuthenticationResponse() { Token = content });
    }
}
