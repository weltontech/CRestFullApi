using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ReadEnderecoDto
    {
        
        public int Id { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
    }
}
