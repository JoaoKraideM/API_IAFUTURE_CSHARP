using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.IAFUTURE.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas às Contas.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly APIDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="ContasController"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ContasController(APIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém a lista de todas as contas.
        /// </summary>
        /// <returns>Uma lista de objetos <see cref="Conta"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conta>>> GetContas()
        {
            return await _context.Contas.ToListAsync();
        }

        /// <summary>
        /// Obtém uma conta específica pelo ID.
        /// </summary>
        /// <param name="id">ID da conta.</param>
        /// <returns>Objeto <see cref="Conta"/> correspondente ao ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(int id)
        {
            var conta = await _context.Contas.FindAsync(id);

            if (conta == null)
            {
                return NotFound();
            }

            return conta;
        }

        /// <summary>
        /// Cria uma nova conta.
        /// </summary>
        /// <param name="conta">Objeto <see cref="Conta"/> a ser criado.</param>
        /// <returns>O objeto <see cref="Conta"/> criado.</returns>
        [HttpPost]
        public async Task<ActionResult<Conta>> PostConta(Conta conta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConta), new { id = conta.IdConta }, conta);
        }

        /// <summary>
        /// Atualiza uma conta existente.
        /// </summary>
        /// <param name="id">ID da conta a ser atualizada.</param>
        /// <param name="conta">Objeto <see cref="Conta"/> com os novos valores.</param>
        /// <returns>Resultado da operação.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConta(int id, Conta conta)
        {
            if (id != conta.IdConta)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(conta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaExists(id))
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
        /// Exclui uma conta pelo ID.
        /// </summary>
        /// <param name="id">ID da conta a ser excluída.</param>
        /// <returns>Resultado da operação.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(int id)
        {
            var conta = await _context.Contas.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }

            _context.Contas.Remove(conta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Verifica se uma conta existe com base no ID.
        /// </summary>
        /// <param name="id">ID da conta.</param>
        /// <returns>Verdadeiro se a conta existir; caso contrário, falso.</returns>
        private bool ContaExists(int id)
        {
            return _context.Contas.Any(e => e.IdConta == id);
        }
    }
}
