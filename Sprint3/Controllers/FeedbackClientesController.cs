using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.IAFUTURE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackClientesController : ControllerBase
    {
        private readonly APIDbContext _context;

        public FeedbackClientesController(APIDbContext context)
        {
            _context = context;
        }

        // GET: FeedbackClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackCliente>>> GetFeedbackClientes()
        {
            return await _context.FeedbacksCliente.ToListAsync();
        }

        // GET: FeedbackClientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackCliente>> GetFeedbackCliente(int id)
        {
            var feedbackCliente = await _context.FeedbacksCliente.FindAsync(id);

            if (feedbackCliente == null)
            {
                return NotFound();
            }

            return feedbackCliente;
        }

        // POST: FeedbackClientes
        [HttpPost]
        public async Task<ActionResult<FeedbackCliente>> PostFeedbackCliente(FeedbackCliente feedbackCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.FeedbacksCliente.Add(feedbackCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeedbackCliente), new { id = feedbackCliente.IdFeedback }, feedbackCliente);
        }


        // PUT: FeedbackClientes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbackCliente(int id, [FromBody] FeedbackCliente feedbackCliente)
        {
            if (id != feedbackCliente.IdFeedback)
            {
                return BadRequest();
            }

            _context.Entry(feedbackCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackClienteExists(id))
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

        // DELETE: FeedbackClientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackCliente(int id)
        {
            var feedbackCliente = await _context.FeedbacksCliente.FindAsync(id);
            if (feedbackCliente == null)
            {
                return NotFound();
            }

            _context.FeedbacksCliente.Remove(feedbackCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackClienteExists(int id)
        {
            return _context.FeedbacksCliente.Any(e => e.IdFeedback == id);
        }
    }
}
