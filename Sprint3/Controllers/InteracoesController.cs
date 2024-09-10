using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.IAFUTURE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteracoesController : ControllerBase
    {
        private readonly APIDbContext _context;

        public InteracoesController(APIDbContext context)
        {
            _context = context;
        }

        // GET: InteracaoClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InteracaoCliente>>> GetInteracaoClientes()
        {
            return await _context.InteracoesCliente.ToListAsync();
        }

        // GET: InteracaoClientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<InteracaoCliente>> GetInteracaoCliente(int id)
        {
            var interacaoCliente = await _context.InteracoesCliente.FindAsync(id);

            if (interacaoCliente == null)
            {
                return NotFound();
            }

            return interacaoCliente;
        }

        // POST: InteracaoClientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostInteracaoCliente(InteracaoCliente interacaoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.InteracoesCliente.Add(interacaoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInteracaoCliente), new { id = interacaoCliente.IdInteracao }, interacaoCliente);
        }

        // PUT: InteracaoClientes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInteracaoCliente(int id, [FromBody] InteracaoCliente interacaoCliente)
        {
            if (id != interacaoCliente.IdInteracao)
            {
                return BadRequest();
            }

            _context.Entry(interacaoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InteracaoClienteExists(id))
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

        // DELETE: InteracaoClientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInteracaoCliente(int id)
        {
            var interacaoCliente = await _context.InteracoesCliente.FindAsync(id);
            if (interacaoCliente == null)
            {
                return NotFound();
            }

            _context.InteracoesCliente.Remove(interacaoCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InteracaoClienteExists(int id)
        {
            return _context.InteracoesCliente.Any(e => e.IdInteracao == id);
        }
    }
}
