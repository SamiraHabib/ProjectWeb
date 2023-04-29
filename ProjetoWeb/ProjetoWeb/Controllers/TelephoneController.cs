using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneController : ControllerBase
    {
        private readonly WebApiContext _context;

        public TelephoneController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Telephone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telephone>>> GetTelephones()
        {
            if (_context.Telephones == null)
            {
                return NotFound();
            }
            return await _context.Telephones.ToListAsync();
        }

        // GET: api/Telephone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telephone>> GetTelephone(int id)
        {
            if (_context.Telephones == null)
            {
                return NotFound();
            }
            var telephone = await _context.Telephones.FindAsync(id);

            if (telephone == null)
            {
                return NotFound();
            }

            return telephone;
        }

        // PUT: api/Telephone/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelephone(int id, Telephone telephone)
        {
            if (id != telephone.IdTelephone)
            {
                return BadRequest();
            }

            _context.Entry(telephone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelephoneExists(id))
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

        // POST: api/Telephone
        [HttpPost]
        public async Task<ActionResult<Telephone>> PostTelephone(Telephone telephone)
        {
            if (_context.Telephones == null)
            {
                return Problem("Entity set 'WebApiContext.Telephones'  is null.");
            }
            _context.Telephones.Add(telephone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelephone", new { id = telephone.IdTelephone }, telephone);
        }

        // DELETE: api/Telephone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelephone(int id)
        {
            if (_context.Telephones == null)
            {
                return NotFound();
            }
            var telephone = await _context.Telephones.FindAsync(id);
            if (telephone == null)
            {
                return NotFound();
            }

            _context.Telephones.Remove(telephone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelephoneExists(int id)
        {
            return (_context.Telephones?.Any(e => e.IdTelephone == id)).GetValueOrDefault();
        }
    }
}