using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Requests.Sales;
using JADWARE.MyShop.Domain.Responses.Products;
using JADWARE.MyShop.Domain.Responses.Sales;

namespace JADWARE.MyShop.Data.Repository
{
    public class SalesRepository: ISalesRepository
    {
        private string _connectionString;
        private readonly ProductRepository _productRepository;

        public SalesRepository()
        {
            _connectionString = Properties.Resources.connectionString;
            _productRepository = new ProductRepository();
        }

        public async Task<bool> InsertItemAsync(InsertSaleRequest request, CancellationToken ct)
        {
            try
            {
                var sqlQuery = new StringBuilder();
                sqlQuery.AppendLine("INSERT INTO VENTAS (CLIENTEID, FECHA, NUMCTAPAGO, TOTAL, PAISENTREGA, ESTADOENTREGA, CIUDADENTREGA, CPENTREGA, DOMICILIOENTREGA)");
                sqlQuery.AppendLine("OUTPUT INSERTED.VENTAID");
                sqlQuery.AppendLine($"VALUES ({request.ClienteId}, GETDATE(), '{request.NumCtaPago}', {request.Total}, '{request.PaisEntrega}', '{request.EstadoEntrega}', '{request.CiudadEntrega}', '{request.CpEntrega}', '{request.DomicilioEntrega}')");

                using var connection = new SqlConnection(_connectionString);
                int ventaId = await connection.QueryFirstAsync<int>(new CommandDefinition(sqlQuery.ToString(), ct));

                foreach(SaleItemRequest saleItem in request.SaleItems)
                {
                    saleItem.VentaId = ventaId;
                    await InsertSaleItemAsync(saleItem, ct);
                    await _productRepository.UpdateProductAmount(saleItem.ProductoId, saleItem.Cantidad, ct);
                }
                return true;
            }    
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> InsertSaleItemAsync(SaleItemRequest request, CancellationToken ct)
        {
            try
            {
                var sqlQuery = new StringBuilder();
                sqlQuery.AppendLine("INSERT INTO VENTAITEM (VENTAID, PRODUCTOID, CANTIDAD, PRECIOUNITARIO, TOTALITEM)");
                sqlQuery.AppendLine($"VALUES ({request.VentaId}, {request.ProductoId}, {request.Cantidad}, {request.PrecioUnitario}, {request.TotalItem})");
                using var connection = new SqlConnection(_connectionString);
                await connection.ExecuteAsync(new CommandDefinition(sqlQuery.ToString(), ct));
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SalesByClientResponse>> GetByClientAsync(GetSalesByClientRequest request, CancellationToken ct)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("SELECT V.VENTAID, V.CLIENTEID, S.STATUS, V.FECHA, V.TOTAL, V.PAISENTREGA, V.ESTADOENTREGA, V.CIUDADENTREGA, V.CPENTREGA, V.DOMICILIOENTREGA");
            sqlQuery.AppendLine("FROM VENTAS V");
            sqlQuery.AppendLine("INNER JOIN STATUS S ON V.STATUS=S.STATUSID");
            sqlQuery.AppendLine($"WHERE V.CLIENTEID={request.ClienteId}");
            using var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<SalesByClientResponse>(sqlQuery.ToString(), ct);
            return response;
        }
    }
}
