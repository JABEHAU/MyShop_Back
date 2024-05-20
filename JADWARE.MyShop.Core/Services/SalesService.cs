using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Requests.Sales;
using JADWARE.MyShop.Domain.Responses.Sales;

namespace JADWARE.MyShop.Core.Services
{
    public class SalesService: ISalesService
    {
        private readonly ISalesRepository _salesRepository;

        public SalesService(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<bool> InsertItemAsync(InsertSaleRequest request, CancellationToken ct)
        {
            return await _salesRepository.InsertItemAsync(request, ct);
        }

        public async Task<IEnumerable<SalesByClientResponse>> GetByClientAsync(GetSalesByClientRequest request, CancellationToken ct)
        {
            return await _salesRepository.GetByClientAsync(request, ct);
        }
    }
}
