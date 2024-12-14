using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuDesafio.Data;
using MottuDesafio.Models;

namespace MottuDesafio.Controllers
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
            return await _context.Locacaos.FirstOrDefaultAsync(l => l.Id == id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AlugarMoto(Locacao loc)
        {
            try
            {
                loc.EntregadorId = loc.EntregadorId;
                loc.MotoId = loc.MotoId;
                loc.DataInicio = DateTime.Now;
                loc.DataTermino = DateTime.Now;
                loc.DataPrevisaoTermino = DateTime.Now;
                loc.Plano = loc.Plano;
                await _context.Locacaos.AddAsync(loc);
                await _context.SaveChangesAsync();
                return Ok("Parabens!! sua moto foi alugada!!");
            }
            catch (System.Exception)
            {
                return BadRequest("Dados inválidos");
            }
        }

        [AllowAnonymous]
        [HttpPut("{id}/devolucao")]
        public async Task<IActionResult> Update(Locacao updateLocacao)
        {
            try
            {
                _context.Locacaos.Update(updateLocacao);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok( new { mensagem = "Data de devolução informada com sucesso",  linhasAfetadas });
            }
            catch (Exception)
            {
                return BadRequest( new { mensagem = "Dados inválidos" });
            }
        }
    }
}
