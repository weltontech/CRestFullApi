﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo de nome é obrigatório.")]
        public string nome { get; set; }

        public int EnderecoId { get; set; }

        //Serve para fazer o relacionamento, mais tmb serve para fazer uma 
        //Instancia do objeto relacionado
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }

    }
}
