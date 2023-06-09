using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly WebApiContext _context;

        public GenreController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            if (_context.Genres == null)
            {
                return NotFound();
            }
            return await _context.Genres.ToListAsync();
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            if (_context.Genres == null)
            {
                return NotFound();
            }
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.IdGenre)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genre
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            if (_context.Genres == null)
            {
                return Problem("Entity set 'WebApiContext.Genres'  is null.");
            }
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.IdGenre }, genre);
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (_context.Genres == null)
            {
                return NotFound();
            }
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreExists(int id)
        {
            return (_context.Genres?.Any(e => e.IdGenre == id)).GetValueOrDefault();
        }
    }
}