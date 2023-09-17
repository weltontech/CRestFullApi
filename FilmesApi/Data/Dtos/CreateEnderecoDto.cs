using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateEnderecoDto
    {
        
        public string logradouro { get; set; }


        public int numero { get; set; }
    }
}
