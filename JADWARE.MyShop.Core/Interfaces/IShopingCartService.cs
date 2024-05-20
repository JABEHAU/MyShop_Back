using JADWARE.MyShop.Domain.Requests.ShopingCart;
using JADWARE.MyShop.Domain.Requests.ShoppingCart;
using JADWARE.MyShop.Domain.Responses.Products;
using JADWARE.MyShop.Domain.Responses.ShopingCart;

namespace JADWARE.MyShop.Core.Interfaces
{
    public interface IShopingCartService
    {
        Task<bool> InsertItemAsync(InsertItemRequest request, CancellationToken ct);
        Task<bool> DeleteItemAsync(DeleteItemRequest request, CancellationToken ct);
        Task<bool> VerifyItemExistsAsync(InsertItemRequest request, CancellationToken ct);
        Task<IEnumerable<GetShopingCartResponse>> GetShoppingCartByUserAsync(GetShoppingCartByUserRequest request, CancellationToken ct);
    }
}
