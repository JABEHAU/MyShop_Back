using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Products;
using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.Data.Repository
{
    public class ProductRepository : IProductRepository
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

        public async Task<IEnumerable<BasicProduct>> GetTopProductsByCategoryAsync(int categoryId, CancellationToken ct)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT TOP 8 P.PRODUCTOID, P.CATEGORIAID, P.NOMBRE, P.PRECIO, P.ESOFERTA, P.PRECIOOFERTA, F.FOTO AS FOTOPRINCIPAL");
            sqlQuery.AppendLine("FROM PRODUCTOS P");
            sqlQuery.AppendLine("OUTER APPLY(");
            sqlQuery.AppendLine("SELECT TOP 1 PRODUCTOID, FOTO");
            sqlQuery.AppendLine("FROM FOTOS");
            sqlQuery.AppendLine("WHERE PRODUCTOID=P.PRODUCTOID) F");
            sqlQuery.AppendLine($"WHERE P.CATEGORIAID={categoryId} AND P.CANTIDAD>0");
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<BasicProduct>(new CommandDefinition(sqlQuery.ToString(), ct));
            return response;
        }

        public async Task<IEnumerable<BasicProduct>> GetAllByCategoryAsync(int categoryId, CancellationToken ct)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT P.PRODUCTOID, P.CATEGORIAID, P.NOMBRE, P.PRECIO, P.ESOFERTA, P.PRECIOOFERTA, F.FOTO AS FOTOPRINCIPAL");
            sqlQuery.AppendLine("FROM PRODUCTOS P");
            sqlQuery.AppendLine("OUTER APPLY(");
            sqlQuery.AppendLine("SELECT TOP 1 PRODUCTOID, FOTO");
            sqlQuery.AppendLine("FROM FOTOS");
            sqlQuery.AppendLine("WHERE PRODUCTOID=P.PRODUCTOID) F");
            sqlQuery.AppendLine($"WHERE P.CATEGORIAID={categoryId} AND P.CANTIDAD>0");
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<BasicProduct>(new CommandDefinition(sqlQuery.ToString(), ct));
            return response;
        }

        public async Task<BasicProduct> GetBasicProductAsync(int productId, CancellationToken ct)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT P.PRODUCTOID, P.CATEGORIAID, P.NOMBRE, P.PRECIO, P.ESOFERTA, P.PRECIOOFERTA, F.FOTO AS FOTOPRINCIPAL, C.CATEGORIA, P.CANTIDAD AS DISPONIBLE");
            sqlQuery.AppendLine("FROM PRODUCTOS P");
            sqlQuery.AppendLine("OUTER APPLY(");
            sqlQuery.AppendLine("SELECT TOP 1 PRODUCTOID, FOTO");
            sqlQuery.AppendLine("FROM FOTOS");
            sqlQuery.AppendLine("WHERE PRODUCTOID=P.PRODUCTOID) F");
            sqlQuery.AppendLine("INNER JOIN CATEGORIAS C ON P.CATEGORIAID=C.CATEGORIAID");
            sqlQuery.AppendLine($"WHERE P.PRODUCTOID={productId} AND P.CANTIDAD>0");
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryFirstAsync<BasicProduct>(new CommandDefinition(sqlQuery.ToString(), ct));
            return response;
        }

        public async Task<Product> GetProductAsync(int productId, CancellationToken ct)
        {
            Product product = new Product();
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT P.PRODUCTOID, P.VENDEDORID, P.CATEGORIAID, P.NOMBRE, P.DESCRIPCION,P.MARCA,");
            sqlQuery.AppendLine("P.MODELO, P.GENERO, P.CANTIDAD, P.PRECIO, P.ESOFERTA, P.PRECIOOFERTA");
            sqlQuery.AppendLine("FROM PRODUCTOS P");
            sqlQuery.AppendLine("WHERE P.PRODUCTOID=@PRODUCTOID");
            var commandDefinition = new CommandDefinition(sqlQuery.ToString(), new { PRODUCTOID = productId }, cancellationToken: ct);

            using var connection = new SqlConnection(_connectionString);
            product = await connection.QueryFirstOrDefaultAsync<Product>(commandDefinition);
            product.Fotos = await GetProductPhotosAsync(productId, ct);
            product.Comentarios = await GetProductCommentsAsync(productId, ct);

            return product;
        }

        public async Task<IEnumerable<Photo>> GetProductPhotosAsync(int productId, CancellationToken ct)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT FOTOID, PRODUCTOID, FOTO");
            sqlQuery.AppendLine("FROM FOTOS");
            sqlQuery.AppendLine("WHERE PRODUCTOID=@PRODUCTOID");
            var commandDefinition = new CommandDefinition(sqlQuery.ToString(), new { PRODUCTOID = productId }, cancellationToken: ct);

            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<Photo>(commandDefinition);

            return response;
        }

        public async Task<IEnumerable<Comment>> GetProductCommentsAsync(int productId, CancellationToken ct)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT C.COMENTARIO, C.CALIFICACION, U.NOMBRE AS COMENTADOR");
            sqlQuery.AppendLine("FROM COMENTARIOS C");
            sqlQuery.AppendLine("INNER JOIN USUARIOS U ON C.COMENTADORID=U.USUARIOID");
            sqlQuery.AppendLine("WHERE C.PRODUCTOID=@PRODUCTOID");

            var commandDefinition = new CommandDefinition(sqlQuery.ToString(), new { PRODUCTOID = productId }, cancellationToken: ct);

            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<Comment>(commandDefinition);

            return response;
        }

        public async Task<bool> UpdateProductAmount(int productId, int amount, CancellationToken ct)
        {
            try
            {
                var sqlQuery = new StringBuilder();
                sqlQuery.AppendLine("Update productos");
                sqlQuery.AppendLine($"set cantidad = cantidad-{amount}");
                sqlQuery.AppendLine($"where productoId={productId}");
                using var connection = new SqlConnection(_connectionString);
                await connection.ExecuteAsync(new CommandDefinition(sqlQuery.ToString(), ct));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<BasicProduct>> SearchByFilter(SearchByFilterRequest request, CancellationToken ct)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT P.PRODUCTOID, P.CATEGORIAID, P.NOMBRE, P.PRECIO, P.ESOFERTA, P.PRECIOOFERTA, F.FOTO AS FOTOPRINCIPAL, C.CATEGORIA, P.CANTIDAD AS DISPONIBLE");
            sqlQuery.AppendLine("FROM PRODUCTOS P");
            sqlQuery.AppendLine("OUTER APPLY(");
            sqlQuery.AppendLine("SELECT TOP 1 PRODUCTOID, FOTO");
            sqlQuery.AppendLine("FROM FOTOS");
            sqlQuery.AppendLine("WHERE PRODUCTOID=P.PRODUCTOID) F");
            sqlQuery.AppendLine("INNER JOIN CATEGORIAS C ON P.CATEGORIAID=C.CATEGORIAID");
            sqlQuery.AppendLine($"WHERE (P.NOMBRE like '%{request.Filter}%' or P.DESCRIPCION like '%{request.Filter}%' OR C.CATEGORIA like '%{request.Filter}%') AND P.CANTIDAD>0");
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<BasicProduct>(new CommandDefinition(sqlQuery.ToString(), ct));
            return response;
        }
    }
}
