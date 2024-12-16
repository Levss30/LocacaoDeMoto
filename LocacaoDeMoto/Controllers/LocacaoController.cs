using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocacaoDeMoto.Data;
using LocacaoDeMoto.Models;
using static LocacaoDeMoto.Models.Locacao;

namespace LocacaoDeMoto.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class LocacaoController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;

        public LocacaoController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Locacao> GetById(int id)
        {
            return await _context.Locacoes.FirstOrDefaultAsync(l => l.Id == id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostLocacao(Locacao l)
        {
            if (l == null)
                return BadRequest(new { mensagem = "Dados inválidos" });

            try
            {
                l.Id = l.Id; 
                l.EntregadorId = l.EntregadorId;
                l.MotoId = l.MotoId;
                l.ValorDiaria = l.ValorDiaria;
                l.Plano = l.Plano;
;               _context.Locacoes.Add(l);
                await _context.SaveChangesAsync();

                return Ok(l);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno no servidor", erro = ex.Message, ex.InnerException });
            }
        }


        [AllowAnonymous]
        [HttpPut("{id}/devolucao")]
        public async Task<IActionResult> Update(long id, [FromBody] LocacaoDevolucaoRequest request)
        {
            try
            {
                var locacaoExistente = await _context.Locacoes.FindAsync(id);

                if (locacaoExistente == null)
                {
                    return NotFound(new { mensagem = "Locação não encontrada" });
                }

                locacaoExistente.DataDevolucao = request.DataDevolucao;

                _context.Locacoes.Update(locacaoExistente);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(new { mensagem = "Data de devolução informada com sucesso"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Dados inválidos", erro = ex.Message });
            }
        }
    }
}
