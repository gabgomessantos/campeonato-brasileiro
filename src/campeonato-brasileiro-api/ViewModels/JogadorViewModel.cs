using System.ComponentModel.DataAnnotations;

namespace campeonato_brasileiro_api.ViewModels
{
    public class JogadorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Pais { get; set; }

        [ScaffoldColumn(false)]
        public string? TimeNome { get; set; }

        public Guid TimeId { get; set; }

        /*-----------------*/
        public IEnumerable<TransferenciaViewModel>? Transferencias { get; set; }
    }
}
