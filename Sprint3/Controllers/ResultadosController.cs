using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.IAFUTURE.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas aos resultados gerados pela IA.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ResultadosController : ControllerBase
    {
        private readonly APIDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="ResultadosController"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ResultadosController(APIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém a lista de todos os resultados da IA.
        /// </summary>
        /// <returns>Uma lista de objetos <see cref="ResultadoIA"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultadoIA>>> GetResultadoIAs()
        {
            return await _context.ResultadosIA.ToListAsync();
        }

        /// <summary>
        /// Obtém um resultado específico gerado pela IA pelo ID.
        /// </summary>
        /// <param name="id">ID do resultado da IA.</param>
        /// <returns>Objeto <see cref="ResultadoIA"/> correspondente ao ID.</returns>
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

        /// <summary>
        /// Cria um novo resultado gerado pela IA.
        /// </summary>
        /// <param name="resultadoIA">Objeto <see cref="ResultadoIA"/> a ser criado.</param>
        /// <returns>O objeto <see cref="ResultadoIA"/> criado.</returns>
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

        /// <summary>
        /// Atualiza um resultado gerado pela IA existente.
        /// </summary>
        /// <param name="id">ID do resultado a ser atualizado.</param>
        /// <param name="resultadoIA">Objeto <see cref="ResultadoIA"/> com os novos valores.</param>
        /// <returns>Resultado da operação.</returns>
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

        /// <summary>
        /// Exclui um resultado gerado pela IA pelo ID.
        /// </summary>
        /// <param name="id">ID do resultado da IA a ser excluído.</param>
        /// <returns>Resultado da operação.</returns>
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

        /// <summary>
        /// Verifica se um resultado gerado pela IA existe com base no ID.
        /// </summary>
        /// <param name="id">ID do resultado da IA.</param>
        /// <returns>Verdadeiro se o resultado existir; caso contrário, falso.</returns>
        private bool ResultadoIAExists(int id)
        {
            return _context.ResultadosIA.Any(e => e.IdResultadoIA == id);
        }
    }
}
