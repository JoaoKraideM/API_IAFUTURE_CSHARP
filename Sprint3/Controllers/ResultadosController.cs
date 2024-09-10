using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.IAFUTURE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultadosController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ResultadosController(APIDbContext context)
        {
            _context = context;
        }

        // GET: ResultadoIAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultadoIA>>> GetResultadoIAs()
        {
            return await _context.ResultadosIA.ToListAsync();
        }

        // GET: ResultadoIAs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultadoIA>> GetResultadoIA(int id)
        {
            var resultadoIA = await _context.ResultadosIA.FindAsync(id);

            if (resultadoIA == null)
            {
                return NotFound();
            }

            return resultadoIA;
        }

        // POST: ResultadoIAs
        [HttpPost]
        public async Task<ActionResult<ResultadoIA>> PostResultadoIA([FromBody] ResultadoIA resultadoIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ResultadosIA.Add(resultadoIA);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResultadoIA), new { id = resultadoIA.IdResultadoIA }, resultadoIA);
        }

        // PUT: ResultadoIAs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultadoIA(int id, [FromBody] ResultadoIA resultadoIA)
        {
            if (id != resultadoIA.IdResultadoIA)
            {
                return BadRequest();
            }

            _context.Entry(resultadoIA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultadoIAExists(id))
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

        // DELETE: ResultadoIAs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResultadoIA(int id)
        {
            var resultadoIA = await _context.ResultadosIA.FindAsync(id);
            if (resultadoIA == null)
            {
                return NotFound();
            }

            _context.ResultadosIA.Remove(resultadoIA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultadoIAExists(int id)
        {
            return _context.ResultadosIA.Any(e => e.IdResultadoIA == id);
        }
    }
}
