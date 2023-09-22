namespace FilmesApi.Data.Dtos
{
    public class UpdateFuncionarioDto
    {
        public int id { get; set; }

        public int Matricula { get; set; }
        public string email { get; set; }

        public string senha { get; set; }
    }
}
