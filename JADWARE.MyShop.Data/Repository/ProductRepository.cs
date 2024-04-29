using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Models;

namespace JADWARE.MyShop.Data.Repository
{
    public class ProductRepository: IProductRepository
    {
        private string _connectionString;

        public ProductRepository()
        {
            _connectionString = Properties.Resources.connectionString;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct)
        {
            string query = "SELECT * FROM PRODUCTOS";
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<Product>(new CommandDefinition(query, ct));
            return response;
        }

        public async Task<IEnumerable<Category>> GetCategories(CancellationToken ct)
        {
            string query = "SELECT * FROM CATEGORIAS";
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<Category>(new CommandDefinition(query, ct));
            return response;
        }
    }
}
