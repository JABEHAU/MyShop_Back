using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.ShopingCart;

namespace JADWARE.MyShop.API.Endpoints.ShoppingCart
{
    public class VerifyExistsItemEndpoint: Endpoint<InsertItemRequest, bool>
    {
        private readonly IShopingCartService _shopingCartService;

        public VerifyExistsItemEndpoint(IShopingCartService shopingCartService)
        {
            _shopingCartService = shopingCartService;
        }

        public override void Configure()
        {
            Post("ShoppingCart/VerifyExists");
            AllowAnonymous();
        }

        public override async Task HandleAsync(InsertItemRequest request, CancellationToken ct)
        {
            var response = await _shopingCartService.VerifyItemExistsAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
