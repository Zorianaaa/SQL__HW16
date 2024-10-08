using Microsoft.AspNetCore.Mvc;
using SQL_library_HW16;
using System.Linq;

namespace LibraryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariansController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public LibrariansController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult LibrarianLogin([FromBody] Librarian librarian)
        {
            var existingLibrarian = _context.Librarians
                .FirstOrDefault(l => l.Login == librarian.Login && l.Password == librarian.Password);

            if (existingLibrarian == null)
                return Unauthorized("Невірний логін або пароль.");

            return Ok("Вхід успішний як бібліотекар.");
        }

        [HttpPost("register")]
        public IActionResult LibrarianRegister([FromBody] Librarian librarian)
        {
            _context.Librarians.Add(librarian);
            _context.SaveChanges();
            return Ok("Реєстрація бібліотекаря успішна.");
        }
    }
}
