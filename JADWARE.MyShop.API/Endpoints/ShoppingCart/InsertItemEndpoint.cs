using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.ShopingCart;

namespace JADWARE.MyShop.API.Endpoints.ShoppingCart
{
    public class InsertItemEndpoint:Endpoint<InsertItemRequest, bool>
    {
        private readonly IShopingCartService _shopingCartService;

        public InsertItemEndpoint(IShopingCartService shopingCartService)
        {
            _shopingCartService = shopingCartService;
        }

        public override void Configure()
        {
            Post("ShoppingCart/InsertItem");
            AllowAnonymous();
        }

        public override async Task HandleAsync(InsertItemRequest request, CancellationToken ct)
        {
            var response = await _shopingCartService.InsertItemAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
