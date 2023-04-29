using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentManagementController : ControllerBase
    {
        private readonly WebApiContext _context;

        public ContentManagementController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/ContentManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentManagement>>> GetContentManagements()
        {
            if (_context.ContentManagements == null)
            {
                return NotFound();
            }
            return await _context.ContentManagements.ToListAsync();
        }

        // GET: api/ContentManagement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentManagement>> GetContentManagement(int id)
        {
            if (_context.ContentManagements == null)
            {
                return NotFound();
            }
            var contentManagement = await _context.ContentManagements.FindAsync(id);

            if (contentManagement == null)
            {
                return NotFound();
            }

            return contentManagement;
        }

        // PUT: api/ContentManagement/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentManagement(int id, ContentManagement contentManagement)
        {
            if (id != contentManagement.IdContentManagement)
            {
                return BadRequest();
            }

            _context.Entry(contentManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentManagementExists(id))
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

        // POST: api/ContentManagement
        [HttpPost]
        public async Task<ActionResult<ContentManagement>> PostContentManagement(ContentManagement contentManagement)
        {
            if (_context.ContentManagements == null)
            {
                return Problem("Entity set 'WebApiContext.ContentManagements'  is null.");
            }
            _context.ContentManagements.Add(contentManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentManagement", new { id = contentManagement.IdContentManagement }, contentManagement);
        }

        // DELETE: api/ContentManagement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentManagement(int id)
        {
            if (_context.ContentManagements == null)
            {
                return NotFound();
            }
            var contentManagement = await _context.ContentManagements.FindAsync(id);
            if (contentManagement == null)
            {
                return NotFound();
            }

            _context.ContentManagements.Remove(contentManagement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentManagementExists(int id)
        {
            return (_context.ContentManagements?.Any(e => e.IdContentManagement == id)).GetValueOrDefault();
        }
    }
}