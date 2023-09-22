using FilmesApi.Models;

namespace FilmesApi.Data.Dtos
{
    public class ReadChamadoDto
    {
        public int Id { get; set; }

        public string titulo { get; set; }

        public string descricao { get; set; }

        public int? PessoaId { get; set; }
        
    }
}
