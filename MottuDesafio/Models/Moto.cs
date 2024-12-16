namespace MottuDesafio.Models
{
    public class Moto
    {
        public long Id { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

        public class MotoPlacaUpdate
        {
            public string Placa { get;  set; }
        }
    }
}
