using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocacaoDeMoto.Data;
using LocacaoDeMoto.Models;
using System.Linq;
using static LocacaoDeMoto.Models.Entregador;

namespace LocacaoDeMoto.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class EntregadoresController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;

        public EntregadoresController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private async Task<bool> EntregadorExistente(string cnpj)
        {
            if (await _context.Entregador.AnyAsync(x => x.Cnpj.ToLower() == cnpj.ToLower()))
            {
                return true;
            }
            return false;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CadastrarEntregador(Entregador ent)
        {
            try
            {
                if (await EntregadorExistente(ent.Cnpj))
                    throw new System.Exception("CNPJ já cadastrado");

                await _context.Entregador.AddAsync(ent);
                await _context.SaveChangesAsync();

                return Ok(new { mensagem = "Entregador cadastrado com sucesso!!", ent.Cnpj });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [AllowAnonymous]
        [HttpPost("{id}/cnh")]
        public async Task<IActionResult> EnviarCnh(long id, [FromBody] AtualizarCnhRequest request)
        {
            try
            {
                var entregador = await _context.Entregador.FindAsync(id);
                if (entregador == null)
                {
                    return NotFound(new { mensagem = "Entregador não encontrado" });
                }

                entregador.FotoCnh = request.FotoCnh;

                _context.Entregador.Update(entregador);
                await _context.SaveChangesAsync();

                return Ok(new { mensagem = "Imagem da CNH enviada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao processar a solicitação", erro = ex.Message });
            }
        }

    }
}
