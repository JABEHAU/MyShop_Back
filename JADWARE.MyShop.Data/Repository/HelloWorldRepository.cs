using JADWARE.MyShop.Core.Interfaces.Repository;

namespace JADWARE.MyShop.Data.Repository
{
    public class HelloWorldRepository: IHelloWorldRepository
    {
        private string _connectionString = "Data Source=JBE-DELL;Initial Catalog=TestingArea;Integrated Security=True;TrustServerCertificate=True";
        public HelloWorldRepository()
        {
            
        }

        public async Task<string> HelloWorldAsync(CancellationToken ct)
        {
            /*string query = "SELECT * FROM PRODUCTOS WHERE CODIGO = 1";
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryFirstAsync(new CommandDefinition(query, ct));*/
            return "Hola Alejandro";
        }

    }
}
