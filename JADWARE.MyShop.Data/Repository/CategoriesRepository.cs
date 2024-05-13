using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Responses.Categories;

namespace JADWARE.MyShop.Data.Repository
{
    public class CategoriesRepository: ICategoriesRepository
    {
        private string _connectionString;
        public CategoriesRepository()
        {
            _connectionString = Properties.Resources.connectionString;
        }
        
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct)
        {
            string query = "SELECT * FROM CATEGORIAS";
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<Category>(new CommandDefinition(query, ct));
            return response;
        }

        public async Task<IEnumerable<Category>> GetTopInOfferAsync(CancellationToken ct)
        {
            var query = new StringBuilder();
            query.AppendLine("SELECT DISTINCT TOP 3 C.CATEGORIAID, C.CATEGORIA, C.IMAGEN");
            query.AppendLine("FROM PRODUCTOS P");
            query.AppendLine("INNER JOIN CATEGORIAS C ON P.CATEGORIAID = C.CATEGORIAID");
            query.AppendLine("WHERE P.ESOFERTA = 1");

            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<Category>(new CommandDefinition(query.ToString(), ct));
            return response;
        }

        public async Task<IEnumerable<CategoryWithProductsResponse>> GetWithTopProductsAsync(CancellationToken ct)
        {
            string query = "SELECT * FROM CATEGORIAS";
            using var connection = new SqlConnection(_connectionString);
            var categories = await connection.QueryAsync<CategoryWithProductsResponse>(new CommandDefinition(query, ct));

            foreach(var category in categories)
            {
                ProductRepository productRepository = new ProductRepository();
                var topProducts = await productRepository.GetTopProductsByCategoryAsync(category.CategoriaId, ct);
                category.Productos = topProducts;
            }

            return categories;
        }
    }
}
