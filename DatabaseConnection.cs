using MySql.Data.MySqlClient;
using System;

namespace Controle_de_funcionarios
{
    public class DatabaseConnection : IDisposable
    {
        private string connectionString;
        private MySqlConnection connection;

        public DatabaseConnection()
        {
            // Conexão com o banco de dados MySQL no XAMPP
            connectionString = "Server=localhost;Database=empresa;User ID=root;Password=;SslMode=none;";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");
                return connection;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
                return null;
            }
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Conexão com o banco de dados fechada.");
            }
        }

        public void Dispose()
        {
            CloseConnection();
            connection?.Dispose();
        }
    }
}
