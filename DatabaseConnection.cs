using MySql.Data.MySqlClient;
using System;

namespace Controle_de_funcionarios
{
    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection()
        {
            // Conexão com o banco de dados MySQL no XAMPP
            connectionString = "Server=localhost;Database=empresa;User ID=root;Password=;SslMode=none;";
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
            return connection;
        }
    }
}

