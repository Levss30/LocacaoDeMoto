using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuDesafio.Data;
using MottuDesafio.Models;
using System.Linq;

namespace MottuDesafio.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class EntregadoresController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;
        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
        public EntregadoresController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            // Criação do diretório de upload se não existir
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
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

    }
}
