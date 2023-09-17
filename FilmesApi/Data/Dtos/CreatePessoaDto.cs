namespace FilmesApi.Data.Dtos
{
    public class CreatePessoaDto
    {
        public string nome { get; set; }

        public string dataNascimento { get; set; }

        public string CPF { get; set; }

        public int EnderecoId { get; set; }
    }
}
