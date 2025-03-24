using Microsoft.Data.SqlClient;

namespace aprendizado
{
    internal class Pessoa(string nome, int idade)
    {
        private static readonly string connectionString = "Server=Kros;Database=aprendizado;Integrated Security=True;TrustServerCertificate=True;";

        public string Nome { get; set; } = nome;
        public int Idade { get; set; } = idade;

        public static void Get()
        {
            using SqlConnection connection = new(connectionString);
            try
            {
                connection.Open();

                string query = "SELECT * FROM pessoa";
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pessoa pessoa = new(reader[1] as string, Convert.ToInt32(reader[2]));

                    Console.WriteLine($"Nome: {pessoa.Nome} e Idade: {pessoa.Idade}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Pessoa.Get();
        }
    }
}
