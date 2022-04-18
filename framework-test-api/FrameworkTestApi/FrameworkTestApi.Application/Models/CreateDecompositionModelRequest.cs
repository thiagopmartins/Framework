using System.ComponentModel.DataAnnotations;

namespace FrameworkTestApi.Application.Models
{
    public class CreateDecompositionModelRequest
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [Range(1, 2000000000, ErrorMessage = "Por favor, escolha um número entre 1 e 2000000000")]
        public int Number { get; set; }
    }
}
