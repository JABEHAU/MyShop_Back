using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.ShopingCart;
using JADWARE.MyShop.Domain.Requests.ShoppingCart;

namespace JADWARE.MyShop.API.Endpoints.ShoppingCart
{
    public class DeleteItemEndpoint:Endpoint<DeleteItemRequest, bool>
    {
        private readonly IShopingCartService _shopingCartService;

        public DeleteItemEndpoint(IShopingCartService shopingCartService)
        {
            _shopingCartService = shopingCartService;
        }

        public override void Configure()
        {
            Post("ShoppingCart/DeleteItem");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteItemRequest request, CancellationToken ct)
        {
            var response = await _shopingCartService.DeleteItemAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
