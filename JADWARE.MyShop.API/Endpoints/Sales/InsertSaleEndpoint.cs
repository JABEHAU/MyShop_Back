using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Services;
using JADWARE.MyShop.Domain.Requests.Sales;

namespace JADWARE.MyShop.API.Endpoints.Sales
{
    public class InsertSaleEndpoint:Endpoint<InsertSaleRequest, bool>
    {
        private readonly ISalesService _salesService;

        public InsertSaleEndpoint(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public override void Configure()
        {
            Post("Sales/Insert");
            AllowAnonymous();
        }

        public override async Task HandleAsync(InsertSaleRequest request, CancellationToken ct)
        {
            var response = await _salesService.InsertItemAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
