using Microsoft.AspNetCore.Mvc;
using SQL_library_HW16;
using System.Linq;

namespace LibraryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public LoansController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLoans()
        {
            var loans = _context.Loans.ToList();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoan(int id)
        {
            var loan = _context.Loans.Find(id);
            if (loan == null)
                return NotFound();

            return Ok(loan);
        }

        [HttpPost]
        public IActionResult CreateLoan([FromBody] Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, loan);
        }

        [HttpPut("{id}/return")]
        public IActionResult ReturnLoan(int id)
        {
            var loan = _context.Loans.Find(id);
            if (loan == null)
                return NotFound();

            loan.ReturnDate = DateTime.Now;
            _context.SaveChanges();

            return Ok("Книга успішно повернена.");
        }
    }
}
