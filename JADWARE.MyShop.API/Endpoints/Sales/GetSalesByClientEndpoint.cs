using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.Sales;
using JADWARE.MyShop.Domain.Responses.Sales;

namespace JADWARE.MyShop.API.Endpoints.Sales
{
    public class GetSalesByClientEndpoint:Endpoint<GetSalesByClientRequest, IEnumerable<SalesByClientResponse>>
    {
        private readonly ISalesService _salesService;

        public GetSalesByClientEndpoint(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public override void Configure()
        {
            Post("Sales/GetByClient");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetSalesByClientRequest request, CancellationToken ct)
        {
            var response = await _salesService.GetByClientAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
