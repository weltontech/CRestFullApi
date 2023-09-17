namespace FilmesApi.Data.Dtos
{
    public class UpdatePessoaDto
    {
        public int Id { get; set; }

        public string nome { get; set; }

        public string dataNascimento { get; set; }

        public string CPF { get; set; }
    }
}
