using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.IAFUTURE.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas ao feedback dos clientes.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FeedbackClientesController : ControllerBase
    {
        private readonly APIDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="FeedbackClientesController"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public FeedbackClientesController(APIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém a lista de todos os feedbacks de clientes.
        /// </summary>
        /// <returns>Uma lista de objetos <see cref="FeedbackCliente"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackCliente>>> GetFeedbackClientes()
        {
            return await _context.FeedbacksCliente.ToListAsync();
        }

        /// <summary>
        /// Obtém um feedback específico de um cliente pelo ID.
        /// </summary>
        /// <param name="id">ID do feedback do cliente.</param>
        /// <returns>Objeto <see cref="FeedbackCliente"/> correspondente ao ID.</returns>
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

        /// <summary>
        /// Cria um novo feedback de cliente.
        /// </summary>
        /// <param name="feedbackCliente">Objeto <see cref="FeedbackCliente"/> a ser criado.</param>
        /// <returns>O objeto <see cref="FeedbackCliente"/> criado.</returns>
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

        /// <summary>
        /// Atualiza um feedback de cliente existente.
        /// </summary>
        /// <param name="id">ID do feedback a ser atualizado.</param>
        /// <param name="feedbackCliente">Objeto <see cref="FeedbackCliente"/> com os novos valores.</param>
        /// <returns>Resultado da operação.</returns>
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

        /// <summary>
        /// Exclui um feedback de cliente pelo ID.
        /// </summary>
        /// <param name="id">ID do feedback do cliente a ser excluído.</param>
        /// <returns>Resultado da operação.</returns>
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

        /// <summary>
        /// Verifica se um feedback de cliente existe com base no ID.
        /// </summary>
        /// <param name="id">ID do feedback do cliente.</param>
        /// <returns>Verdadeiro se o feedback existir; caso contrário, falso.</returns>
        private bool FeedbackClienteExists(int id)
        {
            return _context.FeedbacksCliente.Any(e => e.IdFeedback == id);
        }
    }
}
