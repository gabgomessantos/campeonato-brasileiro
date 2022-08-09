namespace campeonato_brasileiro_business.Models
{
    public class Jogador : Entity
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Pais { get; set; }

        public Guid TimeId { get; set; }

        /*-----------------*/
        public Time Time { get; set; }

        public IEnumerable<Transferencia>? Transferencias { get; set; }
    }
}
