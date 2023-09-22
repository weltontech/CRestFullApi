using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get ; set; }
    
    [Required(ErrorMessage = "O Genero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    
    [Required]
    [Range(70,600, ErrorMessage ="A duração deve ter entre 70 a 600 minutos")]
    public int Duracao { get; set; }

    //fk 1:n
    public virtual ICollection<Sessao> Sessoes { get; set; }
   
}
