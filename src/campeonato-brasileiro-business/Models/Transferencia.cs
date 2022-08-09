namespace campeonato_brasileiro_business.Models
{
    public class Transferencia : Entity
    {
        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public Guid JogadorId { get; set; }

        public Guid TimeOrigemId { get; set; }

        public Guid TimeDestinoId { get; set; }

        /*-----------------*/
        public Jogador Jogador { get; set; }

        public Time TimeOrigem { get; set; }

        public Time TimeDestino { get; set; }
    }
}
