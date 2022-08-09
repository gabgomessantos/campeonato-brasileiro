namespace campeonato_brasileiro_business.Models
{
    public class Time : Entity
    {
        public string Nome { get; set; }

        public string Localidade { get; set; }

        /*-----------------*/
        public IEnumerable<Jogador>? Jogadores { get; set; }

        public IEnumerable<Transferencia>? Transferencias { get; set; }

        public IEnumerable<Torneio>? Torneios { get; set; }

        public IEnumerable<Partida>? Partidas { get; set; }
    }
}
