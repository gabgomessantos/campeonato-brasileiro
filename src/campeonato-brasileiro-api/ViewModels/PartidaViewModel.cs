using System.ComponentModel.DataAnnotations;

namespace campeonato_brasileiro_api.ViewModels
{
    public class PartidaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TorneioId { get; set; }

        public Guid TimeMandanteId { get; set; }

        public Guid TimeVisitanteId { get; set; }

        [ScaffoldColumn(false)]
        public string? TorneioNome { get; set; }

        [ScaffoldColumn(false)]
        public string? TimeMandanteNome { get; set; }

        [ScaffoldColumn(false)]
        public string? TimeVisitanteNome { get; set; }

        /*-----------------*/
        public IEnumerable<EventoViewModel>? Eventos { get; set; }
    }
}
