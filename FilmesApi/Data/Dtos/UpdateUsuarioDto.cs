using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class UpdateUsuarioDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        public string dataNascimento { get; set; }
    }
}
