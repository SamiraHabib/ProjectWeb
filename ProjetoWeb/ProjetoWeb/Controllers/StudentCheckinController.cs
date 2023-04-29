using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCheckinController : ControllerBase
    {
        private readonly WebApiContext _context;

        public StudentCheckinController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/StudentCheckin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCheckin>>> GetStudentCheckins()
        {
            if (_context.StudentCheckins == null)
            {
                return NotFound();
            }
            return await _context.StudentCheckins.ToListAsync();
        }

        // GET: api/StudentCheckin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCheckin>> GetStudentCheckin(int id)
        {
            if (_context.StudentCheckins == null)
            {
                return NotFound();
            }
            var studentCheckin = await _context.StudentCheckins.FindAsync(id);

            if (studentCheckin == null)
            {
                return NotFound();
            }

            return studentCheckin;
        }

        // PUT: api/StudentCheckin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentCheckin(int id, StudentCheckin studentCheckin)
        {
            if (id != studentCheckin.IdStudent)
            {
                return BadRequest();
            }

            _context.Entry(studentCheckin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentCheckinExists(id))
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

        // POST: api/StudentCheckin
        [HttpPost]
        public async Task<ActionResult<StudentCheckin>> PostStudentCheckin(StudentCheckin studentCheckin)
        {
            if (_context.StudentCheckins == null)
            {
                return Problem("Entity set 'WebApiContext.StudentCheckins'  is null.");
            }
            _context.StudentCheckins.Add(studentCheckin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentCheckinExists(studentCheckin.IdStudent))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentCheckin", new { id = studentCheckin.IdStudent }, studentCheckin);
        }

        // DELETE: api/StudentCheckin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentCheckin(int id)
        {
            if (_context.StudentCheckins == null)
            {
                return NotFound();
            }
            var studentCheckin = await _context.StudentCheckins.FindAsync(id);
            if (studentCheckin == null)
            {
                return NotFound();
            }

            _context.StudentCheckins.Remove(studentCheckin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentCheckinExists(int id)
        {
            return (_context.StudentCheckins?.Any(e => e.IdStudent == id)).GetValueOrDefault();
        }
    }
}