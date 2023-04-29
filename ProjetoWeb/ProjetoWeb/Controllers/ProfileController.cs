using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly WebApiContext _context;

        public ProfileController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            if (_context.Profiles == null)
            {
                return NotFound();
            }
            return await _context.Profiles.ToListAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(int id)
        {
            if (_context.Profiles == null)
            {
                return NotFound();
            }
            var profile = await _context.Profiles.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile profile)
        {
            if (id != profile.IdProfile)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profile
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            if (_context.Profiles == null)
            {
                return Problem("Entity set 'WebApiContext.Profiles'  is null.");
            }
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.IdProfile }, profile);
        }

        // DELETE: api/Profile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            if (_context.Profiles == null)
            {
                return NotFound();
            }
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(int id)
        {
            return (_context.Profiles?.Any(e => e.IdProfile == id)).GetValueOrDefault();
        }
    }
}