using System.ComponentModel.DataAnnotations;

namespace LAB_APP.API.Models
{
    public class EscolaViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email não está em um formato válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Número de Salas é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O Número de Salas deve ser maior que zero.")]
        public int NumeroDeSalas { get; set; }

        [Required(ErrorMessage = "O campo Província é obrigatório.")]
        public string? Provincia { get; set; }
    }
}
