using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        //Relacionamento dizemos que uma sessao para ser criada requer um FilmeId
        
        public int? FilmeId { get; set; }

        //relação estabelecida
        public virtual Filme Filme { get; set; }

        //? diz que o valor pode ser nullo
        public int? CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

    }
}
