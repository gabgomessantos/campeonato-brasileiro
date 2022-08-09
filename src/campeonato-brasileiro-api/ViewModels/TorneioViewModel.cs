using System.ComponentModel.DataAnnotations;

namespace campeonato_brasileiro_api.ViewModels
{
    public class TorneioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        /*-----------------*/
        public IEnumerable<TimeViewModel>? Times { get; set; }

        public IEnumerable<PartidaViewModel>? Partidas { get; set; }
    }
}
