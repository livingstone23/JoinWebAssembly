using JOIN.WASM.Server.Models;
using JOIN.WASM.Shared;
using Microsoft.AspNetCore.Mvc;

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


    }
}