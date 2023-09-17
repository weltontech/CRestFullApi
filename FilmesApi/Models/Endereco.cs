using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
       
        public string logradouro { get; set; }

        
        public int numero { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Pessoa Pessoa { get; set; }

    }
}
