using Microsoft.AspNetCore.Mvc;
using SQL_library_HW16;
using System.Linq;

namespace LibraryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public ReadersController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Reader reader)
        {
            var existingReader = _context.Readers
                .FirstOrDefault(r => r.Login == reader.Login && r.Password == reader.Password);

            if (existingReader == null)
                return Unauthorized();

            return Ok("Login successful");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Reader reader)
        {
            _context.Readers.Add(reader);
            _context.SaveChanges();
            return Ok("Registration successful");
        }
    }
}
