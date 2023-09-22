using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Chamado
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string titulo { get; set; }

        public string descricao { get; set; }

        //fk chamado pessoa
        public int? PessoaId { get; set; }
        public virtual Pessoa Pessoa{ get; set; }

    }
}
