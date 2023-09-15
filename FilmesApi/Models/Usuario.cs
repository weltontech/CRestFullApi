using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Usuario
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    public string nome { get; set; }

    [Required(ErrorMessage ="A data é obrigatória")]
    public string dataNascimento { get; set; }
}
