using MySql.Data.MySqlClient;

namespace EasyEscale
{
    internal static class Conexao
    {
        private const string ConnectionString = "server=localhost;user=root;password=root;database=easyescale";

        public static MySqlConnection Nova() => new MySqlConnection(ConnectionString);
    }
}
