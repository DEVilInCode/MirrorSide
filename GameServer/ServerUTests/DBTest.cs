using Server.Controllers;
using Server.Models;
using Server.Services;
using SharedLibrary;
using SharedLibrary.Requests;

namespace ServerUTests
{
    [TestClass]
    public class DBTest
    {
        private readonly Settings _settings = new() { BearerKey = "SomePasswordHere" };
        private readonly MongoDBContext _context = new ("mongodb://localhost:27017", "MockGameDB");

        

        [TestMethod]
        public async Task TestRegister()
        {
            AuthenticationService s = new(_settings, _context);

            string username = "admin2";
            string password = "admin2";
            var (success, content) = await s.RegisterAsync(username, password);

            Assert.IsTrue(success);

            await _context.RemoveUserAsync(new User() { Username = username });
        }

        [TestMethod]
        public async Task TakedUsername()
        {
            AuthenticationService s = new(_settings, _context);

            string username = "admin1";
            string password = "admin1";
            var (success, content) = await s.RegisterAsync(username, password);

            Assert.IsTrue(content.SequenceEqual("Username is not available"));
        }


        [TestMethod]
        public async Task TestLogin()
        {
            AuthenticationService s = new(_settings, _context);

            string username = "admin";
            string password = "admin";

            var (success, content) = await s.LoginAsync(username, password);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public async Task WrongUsername()
        {
            AuthenticationService s = new(_settings, _context);

            string username = "admins";
            string password = "admin";

            var (success, content) = await s.LoginAsync(username, password);

            Assert.IsTrue(content.SequenceEqual("Invalid username"));
        }

        [TestMethod]
        public async Task WrongPassword()
        {
            AuthenticationService s = new(_settings, _context);

            string username = "admin";
            string password = "admins";

            var (success, content) = await s.LoginAsync(username, password);

            Assert.IsTrue(content.SequenceEqual("Invalid password"));
        }
    }
}