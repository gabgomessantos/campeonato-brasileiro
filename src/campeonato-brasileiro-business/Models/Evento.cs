namespace campeonato_brasileiro_business.Models
{
    public class Evento : Entity
    {
        public TipoEvento TipoEvento { get; set; }

        public DateTime Data { get; set; }

        public Guid PartidaId { get; set; }

        /*-----------------*/
        public Partida Partida { get; set; }
    }
}
