using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string nome { get; set; }

        public string dataNascimento { get; set; }

        public string CPF { get; set; }

        public int EnderecoId { get; set; }

        //Serve para fazer o relacionamento, mais tmb serve para fazer uma 
        //Instancia do objeto relacionado
        public virtual Endereco Endereco { get; set; }

        // fk 1:n Pessoa:Chamados 
        public virtual ICollection<Chamado> Chamados { get; set; }

    }
}
