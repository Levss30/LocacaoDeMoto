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
    public class MotosController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;
        public MotosController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private async Task<bool> MotoExistente(string placa)
        {
            if (await _context.Motos.AnyAsync(x => x.Placa.ToLower() == placa.ToLower()))
            {
                return true;
            }
            return false;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CadastrarMoto(Moto moto)
        {
            try
            {
                if (await MotoExistente(moto.Placa))
                    throw new System.Exception("Placa já cadastrada");

                await _context.Motos.AddAsync(moto);
                await _context.SaveChangesAsync();

                return Ok( new { mensagem = "Moto cadastrada com sucesso!!", moto.Id });
            }
            catch (System.Exception)
            {
                return BadRequest("Dados inválidos");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Moto>> GetMotos()
        {
            return await _context.Motos.ToListAsync();
        }

        [AllowAnonymous]
        [HttpPut("{id}/{placa}")]
        public async Task<IActionResult> UpdateMoto(Moto updateMoto)
        {
            try
            {
                _context.Motos.Update(updateMoto);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Moto> GetByPId(int id)
        {
            return await _context.Motos.FirstOrDefaultAsync(m => m.Id == id);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto(int id)
        {
            try
            {
                Moto mRemover = await _context.Motos
                    .FirstOrDefaultAsync(m => m.Id == id);
                _context.Motos.Remove(mRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
