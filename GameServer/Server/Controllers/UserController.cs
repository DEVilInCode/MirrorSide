using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Server.Services;
using SharedLibrary;

namespace Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IPlayerService _playerService;
    private readonly MongoDBContext _context;

    public UserController(IPlayerService playerService, MongoDBContext context) 
    {
        _playerService = playerService; 
        _context = context;
    }

    [HttpGet("{id}")]
    public User Get([FromRoute] string id) 
    {
        User player = new() { Id = id };

        _playerService.DoSomething();

        return player;
    }

    [HttpPost]
    public User Post(User player)
    {
        Console.WriteLine("Player aded to db");
        return player;
    }
}
