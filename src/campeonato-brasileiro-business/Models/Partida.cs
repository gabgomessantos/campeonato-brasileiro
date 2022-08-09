namespace campeonato_brasileiro_business.Models
{
    public class Partida : Entity
    {
        public Guid TorneioId { get; set; }

        public Guid TimeMandanteId { get; set; }

        public Guid TimeVisitanteId { get; set; }

        /*-----------------*/
        public Torneio Torneio { get; set; }

        public Time TimeMandante { get; set; }

        public Time TimeVisitante { get; set; }

        public IEnumerable<Evento>? Eventos { get; set; }
    }
}
