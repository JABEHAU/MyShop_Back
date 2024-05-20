using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Requests.ShopingCart;
using JADWARE.MyShop.Domain.Requests.ShoppingCart;
using JADWARE.MyShop.Domain.Responses.Products;
using JADWARE.MyShop.Domain.Responses.ShopingCart;

namespace JADWARE.MyShop.Data.Repository
{
    public class ShopingCartRepository: IShoppingCartRepository
    {
        private string _connectionString;
        private string _tableName = "CARRITOITEM";
        private ProductRepository _productRepository;

        public ShopingCartRepository()
        {
            _connectionString = Properties.Resources.connectionString;
            _productRepository = new ProductRepository();
        }

        public async Task<bool> InsertItemAsync(InsertItemRequest request, CancellationToken ct)
        {
            try
            {
                var sqlQuery = new StringBuilder();
                sqlQuery.AppendLine($"INSERT INTO {_tableName} (productoId, usuarioId)");
                sqlQuery.AppendLine($"VALUES ({request.ProductoId}, {request.UsuarioId})");

                using var connection = new SqlConnection( _connectionString );
                await connection.ExecuteAsync(new CommandDefinition(sqlQuery.ToString(), ct));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(DeleteItemRequest request, CancellationToken ct)
        {
            try
            {
                var sqlQuery = new StringBuilder();
                sqlQuery.AppendLine($"DELETE FROM {_tableName}");
                sqlQuery.Append($"WHERE ITEMID={request.ItemId}");
                using var connection = new SqlConnection(_connectionString);
                await connection.ExecuteAsync(new CommandDefinition(sqlQuery.ToString(), ct));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> VerifyItemExistsAsync(InsertItemRequest request, CancellationToken ct)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine($"SELECT COUNT(*) FROM {_tableName}");
            sqlQuery.AppendLine($"WHERE USUARIOID=@USUARIOID AND PRODUCTOID=@PRODUCTOID AND ITEMID>0");
            var commandDefinition = new CommandDefinition(sqlQuery.ToString(),new { USUARIOID = request.UsuarioId, PRODUCTOID = request.ProductoId}, cancellationToken: ct);

            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryFirstAsync<int>(commandDefinition);

            if (response < 1)
                return false;

            return true;
        }

        public async Task<IEnumerable<GetShopingCartResponse>> GetShoppingCartByUserAsync(GetShoppingCartByUserRequest request, CancellationToken ct)
        {
            string sqlQuery = $"SELECT * FROM CARRITOITEM WHERE USUARIOID={request.usuarioId} AND ITEMID>0";
            using var connection = new SqlConnection(_connectionString);
            var itemsShoppingCart = await connection.QueryAsync<GetShopingCartResponse>(new CommandDefinition(sqlQuery, ct));

            foreach(var item in itemsShoppingCart)
            {
                item.ProductDetail = await _productRepository.GetBasicProductAsync(item.ProductoId, ct);
            }

            return itemsShoppingCart;
        }
    }
}
