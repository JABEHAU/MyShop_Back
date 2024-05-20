using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.ShoppingCart;
using JADWARE.MyShop.Domain.Responses.Products;
using JADWARE.MyShop.Domain.Responses.ShopingCart;

namespace JADWARE.MyShop.API.Endpoints.ShoppingCart
{
    public class GetShoppingCartByUserEndpoint:Endpoint<GetShoppingCartByUserRequest, IEnumerable<GetShopingCartResponse>>
    {
        private readonly IShopingCartService _shopingCartService;

        public GetShoppingCartByUserEndpoint(IShopingCartService shopingCartService)
        {
            _shopingCartService = shopingCartService;
        }

        public override void Configure()
        {
            Post("ShoppingCart/GetByUser");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetShoppingCartByUserRequest request, CancellationToken ct)
        {
            var response = await _shopingCartService.GetShoppingCartByUserAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
