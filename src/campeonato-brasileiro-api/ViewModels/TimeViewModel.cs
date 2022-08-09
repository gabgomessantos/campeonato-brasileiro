using System.ComponentModel.DataAnnotations;

namespace campeonato_brasileiro_api.ViewModels
{
    public class TimeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Localidade { get; set; }

        /*-----------------*/
        public IEnumerable<JogadorViewModel>? Jogadores { get; set; }
    }
}
