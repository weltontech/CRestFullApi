using System.ComponentModel.DataAnnotations;
using FilmesApi.Models;

namespace FilmesApi.Data.Dtos
{
    public class CreateChamadoDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int PessoaId { get; set; }
    }
}


