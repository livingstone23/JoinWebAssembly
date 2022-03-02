using JOIN.WASM.Server.Models;
using JOIN.WASM.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JOIN.WASM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public List<Contact> Get()
        {
            List<User> users = _context.Users.ToList();
            List<Contact> contacts = new List<Contact>();
            int i = 1;

            foreach(var user in users)
            {
                contacts.Add(new Contact(i++, user.FirstName, user.LastName));
            }

            return contacts;
        }


        [HttpPut("updateprofile/{userId}")]
        public async Task<User> UpdateProfile(int userId, [FromBody] User user)
        {

            User userToUpdate = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.EmailAddress = user.EmailAddress;

            await _context.SaveChangesAsync();

            return await Task.FromResult(userToUpdate);
        }

        [HttpGet("getprofile/{userId}")]
        public async Task<User> GetProfile(int userId)
        {
            return await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }


    }
}