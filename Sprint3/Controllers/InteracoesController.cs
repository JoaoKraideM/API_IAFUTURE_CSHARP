using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.IAFUTURE.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas às interações dos clientes.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class InteracoesController : ControllerBase
    {
        private readonly APIDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="InteracoesController"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public InteracoesController(APIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém a lista de todas as interações de clientes.
        /// </summary>
        /// <returns>Uma lista de objetos <see cref="InteracaoCliente"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InteracaoCliente>>> GetInteracaoClientes()
        {
            return await _context.InteracoesCliente.ToListAsync();
        }

        /// <summary>
        /// Obtém uma interação específica de um cliente pelo ID.
        /// </summary>
        /// <param name="id">ID da interação do cliente.</param>
        /// <returns>Objeto <see cref="InteracaoCliente"/> correspondente ao ID.</returns>
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

        /// <summary>
        /// Cria uma nova interação de cliente.
        /// </summary>
        /// <param name="interacaoCliente">Objeto <see cref="InteracaoCliente"/> a ser criado.</param>
        /// <returns>O objeto <see cref="InteracaoCliente"/> criado.</returns>
        [HttpPost]
        public async Task<ActionResult<InteracaoCliente>> PostInteracaoCliente(InteracaoCliente interacaoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InteracoesCliente.Add(interacaoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInteracaoCliente), new { id = interacaoCliente.IdInteracao }, interacaoCliente);
        }

        /// <summary>
        /// Atualiza uma interação de cliente existente.
        /// </summary>
        /// <param name="id">ID da interação a ser atualizada.</param>
        /// <param name="interacaoCliente">Objeto <see cref="InteracaoCliente"/> com os novos valores.</param>
        /// <returns>Resultado da operação.</returns>
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

        /// <summary>
        /// Exclui uma interação de cliente pelo ID.
        /// </summary>
        /// <param name="id">ID da interação do cliente a ser excluída.</param>
        /// <returns>Resultado da operação.</returns>
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

        /// <summary>
        /// Verifica se uma interação de cliente existe com base no ID.
        /// </summary>
        /// <param name="id">ID da interação do cliente.</param>
        /// <returns>Verdadeiro se a interação existir; caso contrário, falso.</returns>
        private bool InteracaoClienteExists(int id)
        {
            return _context.InteracoesCliente.Any(e => e.IdInteracao == id);
        }
    }
}
