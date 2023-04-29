using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly WebApiContext _context;

        public PaymentTypeController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/PaymentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentType>>> GetPaymentTypes()
        {
            if (_context.PaymentTypes == null)
            {
                return NotFound();
            }
            return await _context.PaymentTypes.ToListAsync();
        }

        // GET: api/PaymentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentType>> GetPaymentType(int id)
        {
            if (_context.PaymentTypes == null)
            {
                return NotFound();
            }
            var paymentType = await _context.PaymentTypes.FindAsync(id);

            if (paymentType == null)
            {
                return NotFound();
            }

            return paymentType;
        }

        // PUT: api/PaymentType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentType(int id, PaymentType paymentType)
        {
            if (id != paymentType.IdPaymentType)
            {
                return BadRequest();
            }

            _context.Entry(paymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
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

        // POST: api/PaymentType
        [HttpPost]
        public async Task<ActionResult<PaymentType>> PostPaymentType(PaymentType paymentType)
        {
            if (_context.PaymentTypes == null)
            {
                return Problem("Entity set 'WebApiContext.PaymentTypes'  is null.");
            }
            _context.PaymentTypes.Add(paymentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentType", new { id = paymentType.IdPaymentType }, paymentType);
        }

        // DELETE: api/PaymentType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentType(int id)
        {
            if (_context.PaymentTypes == null)
            {
                return NotFound();
            }
            var paymentType = await _context.PaymentTypes.FindAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            _context.PaymentTypes.Remove(paymentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTypeExists(int id)
        {
            return (_context.PaymentTypes?.Any(e => e.IdPaymentType == id)).GetValueOrDefault();
        }
    }
}