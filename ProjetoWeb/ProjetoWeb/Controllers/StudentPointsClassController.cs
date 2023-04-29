using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPointsClassController : ControllerBase
    {
        private readonly WebApiContext _context;

        public StudentPointsClassController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/StudentPointsClass
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentPointsClass>>> GetStudentPointsClasses()
        {
            if (_context.StudentPointsClasses == null)
            {
                return NotFound();
            }
            return await _context.StudentPointsClasses.ToListAsync();
        }

        // GET: api/StudentPointsClass/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentPointsClass>> GetStudentPointsClass(int id)
        {
            if (_context.StudentPointsClasses == null)
            {
                return NotFound();
            }
            var studentPointsClass = await _context.StudentPointsClasses.FindAsync(id);

            if (studentPointsClass == null)
            {
                return NotFound();
            }

            return studentPointsClass;
        }

        // PUT: api/StudentPointsClass/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentPointsClass(int id, StudentPointsClass studentPointsClass)
        {
            if (id != studentPointsClass.IdStudent)
            {
                return BadRequest();
            }

            _context.Entry(studentPointsClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentPointsClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentPointsClass
        [HttpPost]
        public async Task<ActionResult<StudentPointsClass>> PostStudentPointsClass(StudentPointsClass studentPointsClass)
        {
            if (_context.StudentPointsClasses == null)
            {
                return Problem("Entity set 'WebApiContext.StudentPointsClasses'  is null.");
            }
            _context.StudentPointsClasses.Add(studentPointsClass);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentPointsClassExists(studentPointsClass.IdStudent))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentPointsClass", new { id = studentPointsClass.IdStudent }, studentPointsClass);
        }

        // DELETE: api/StudentPointsClass/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentPointsClass(int id)
        {
            if (_context.StudentPointsClasses == null)
            {
                return NotFound();
            }
            var studentPointsClass = await _context.StudentPointsClasses.FindAsync(id);
            if (studentPointsClass == null)
            {
                return NotFound();
            }

            _context.StudentPointsClasses.Remove(studentPointsClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentPointsClassExists(int id)
        {
            return (_context.StudentPointsClasses?.Any(e => e.IdStudent == id)).GetValueOrDefault();
        }
    }
}