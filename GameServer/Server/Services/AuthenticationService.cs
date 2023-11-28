using MongoDB.Driver;
using Server.Models;
using SharedLibrary;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Server.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly Settings _settings;
    private readonly MongoDBContext _context;

    public AuthenticationService(Settings settings, MongoDBContext context)
    {
        _settings = settings;
        _context = context;
    }

    public (bool success, string content) Register(string username, string password)
    {
        if (_context.Users.Find(u => u.Username == username).Any()) return (false, "Username is not available");

        User user = new() { Username = username, PasswordHash = password };
        user.ProvideSaltAndHash();

        _context.AddUser(user);

        return (true, "");
    }

    public (bool success, string token) Login(string username, string password)
    {
        User user = _context.Users.Find(u => u.Username == username).FirstOrDefault();
        if (user == null) return (false, "Invalid username");

        if (user.PasswordHash != AuthenticationHelpers.ComputeHash(password, user.Salt)) return (false, "Invalid password");

        return (true, GenerateJwtToken(AssembleClaimsIdentity(user)));
    }

    private ClaimsIdentity AssembleClaimsIdentity(User user)
    {
        ClaimsIdentity subject = new(new[]
        {
            new Claim("id", user.Id.ToString())
        });

        return subject;
    }

    private string GenerateJwtToken(ClaimsIdentity subject)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = new byte[32];
        new RNGCryptoServiceProvider().GetBytes(key);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = subject,
            Expires = DateTime.Now.AddYears(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

public interface IAuthenticationService
{
    (bool success, string content) Register(string username, string password);
    (bool success, string token) Login(string username, string password);
}

public static class AuthenticationHelpers
{
    public static void ProvideSaltAndHash(this User user)
    {
        byte[] salt = GenerateSalt();
        user.Salt = Convert.ToBase64String(salt);
        user.PasswordHash = ComputeHash(user.PasswordHash, user.Salt);
    }

    private static byte[] GenerateSalt()
    {
        RandomNumberGenerator randomNumGen = RandomNumberGenerator.Create();
        byte[] salt = new byte[24];
        randomNumGen.GetBytes(salt);
        return salt;
    }

    public static string ComputeHash(string password, string saltString)
    {
        byte[] salt = Convert.FromBase64String(saltString);

        using Rfc2898DeriveBytes hashGen = new(password, salt);
        hashGen.IterationCount = 10101;
        byte[] bytes = hashGen.GetBytes(24);
        return Convert.ToBase64String(bytes);
    }
}
