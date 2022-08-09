namespace campeonato_brasileiro_business.Models
{
    public class Torneio : Entity
    {
        public string Nome { get; set; }

        /*-----------------*/
        public IEnumerable<Time>? Times { get; set; }

        public IEnumerable<Partida>? Partidas { get; set; }
    }
}
