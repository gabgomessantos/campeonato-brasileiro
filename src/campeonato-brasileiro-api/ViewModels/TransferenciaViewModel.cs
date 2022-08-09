using System.ComponentModel.DataAnnotations;

namespace campeonato_brasileiro_api.ViewModels
{
    public class TransferenciaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        public string? JogadorNome { get; set; }

        [ScaffoldColumn(false)]
        public string? TimeOrigemNome { get; set; }

        [ScaffoldColumn(false)]
        public string? TimeDestinoNome { get; set; }

        public Guid JogadorId { get; set; }

        public Guid TimeOrigemId { get; set; }

        public Guid TimeDestinoId { get; set; }
    }
}
