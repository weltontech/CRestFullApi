namespace FilmesApi.Models
{
    public class Funcionario : Pessoa
    {
        
        public int Matricula { get; set; }
        public string email { get; set; }

        public string senha { get; set; }

    }
}
