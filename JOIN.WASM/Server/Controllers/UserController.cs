using JOIN.WASM.Server.Models;
using JOIN.WASM.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JOIN.WASM.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;
        private readonly BlazingChatContext _context;

        public UserController(ILogger<UserController> logger, BlazingChatContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        [HttpGet("getcontacts")]
        public List<User> GetContacts()
        {
            return _context.Users.ToList();
        }

        [HttpPut("updateprofile/{userId}")]
        public async Task<User> UpdateProfile(int userId, [FromBody] User user)
        {
            User userToUpdate = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.EmailAddress = user.EmailAddress;
            userToUpdate.AboutMe = user.AboutMe;

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }

        [HttpGet("getprofile/{userId}")]
        public async Task<User> GetProfile(int userId)
        {
            return await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        [HttpGet("updatetheme")]
        public async Task<User> UpdateTheme(string userId, string value)
        {
            User user = _context.Users.Where(u => u.UserId == Convert.ToInt32(userId)).FirstOrDefault();
            user.DarkTheme = value == "True" ? 1 : 0;

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }

        [HttpGet("updatenotifications")]
        public async Task<User> UpdateNotifications(string userId, string value)
        {
            User user = _context.Users.Where(u => u.UserId == Convert.ToInt32(userId)).FirstOrDefault();
            user.Notifications = value == "True" ? 1 : 0;

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }


    }
}