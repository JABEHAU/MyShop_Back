using JADWARE.MyShop.Domain.Requests.Sales;
using JADWARE.MyShop.Domain.Responses.Sales;

namespace JADWARE.MyShop.Core.Interfaces.Repository
{
    public interface ISalesRepository
    {
        Task<bool> InsertItemAsync(InsertSaleRequest request, CancellationToken ct);
        Task<IEnumerable<SalesByClientResponse>> GetByClientAsync(GetSalesByClientRequest request, CancellationToken ct);
    }
}
