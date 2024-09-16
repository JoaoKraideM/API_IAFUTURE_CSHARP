using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IAFUTURE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ClientesController(APIDbContext context)
        {
            _context = context;
        }

        ///<summary>
        /// Obtém todos os clientes.
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna uma lista completa de clientes cadastrados.
        /// </remarks>
        /// <returns>Uma lista de clientes.</returns>
        /// <response code="200">Retorna a lista de clientes com sucesso.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        /// <summary>
        /// Obtém um cliente específico pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente que deseja obter.</param>
        /// <returns>O cliente com o ID especificado.</returns>
        /// <response code="200">Retorna o cliente com sucesso.</response>
        /// <response code="404">Se o cliente não for encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="cliente">Objeto cliente que será criado.</param>
        /// <returns>O cliente criado.</returns>
        /// <response code="201">Retorna o cliente recém-criado.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdCliente }, cliente);
        }

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="id">ID do cliente que deseja atualizar.</param>
        /// <param name="cliente">Objeto cliente com os novos dados.</param>
        /// <returns>Sem conteúdo se a atualização for bem-sucedida.</returns>
        /// <response code="204">Cliente atualizado com sucesso.</response>
        /// <response code="400">Se os dados forem inválidos ou os IDs não coincidirem.</response>
        /// <response code="404">Se o cliente não for encontrado.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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
        /// Exclui um cliente específico pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente que deseja excluir.</param>
        /// <returns>Sem conteúdo se a exclusão for bem-sucedida.</returns>
        /// <response code="204">Cliente excluído com sucesso.</response>
        /// <response code="404">Se o cliente não for encontrado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
