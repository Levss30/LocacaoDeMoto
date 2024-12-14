using System.Text.Json.Serialization;

namespace MottuDesafio.Models
{
    public class Locacao
    {
        public long Id { get; set; }
        public int EntregadorId { get; set; }
        public int MotoId { get; set; }
        public int ValorDiaria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int Plano { get; set; }
        public Moto Moto { get; set; }
        public Entregador Entregador { get; set; }
    }
}
