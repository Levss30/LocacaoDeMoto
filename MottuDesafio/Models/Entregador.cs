using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MottuDesafio.Models
{
    public class Entregador
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNasc { get; set; }
        public string NumeroCnh { get; set; }
        public string TipoCnh { get; set; }
        public string FotoCnh { get; set; }

        public class AtualizarCnhRequest
        {
            public string FotoCnh { get; set; }
        }
    }
}
