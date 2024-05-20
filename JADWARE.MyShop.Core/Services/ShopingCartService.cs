using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Requests.ShopingCart;
using JADWARE.MyShop.Domain.Requests.ShoppingCart;
using JADWARE.MyShop.Domain.Responses.Products;
using JADWARE.MyShop.Domain.Responses.ShopingCart;

namespace JADWARE.MyShop.Core.Services
{
    public class ShopingCartService:IShopingCartService
    {
        private readonly IShoppingCartRepository _shopingCartRepository;

        public ShopingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shopingCartRepository = shoppingCartRepository;
        }
        public async Task<bool> InsertItemAsync(InsertItemRequest request, CancellationToken ct)
        {
            return await _shopingCartRepository.InsertItemAsync(request, ct);
        }

        public async Task<bool> DeleteItemAsync(DeleteItemRequest request, CancellationToken ct)
        {
            return await _shopingCartRepository.DeleteItemAsync(request, ct);
        }

        public async Task<bool> VerifyItemExistsAsync(InsertItemRequest request, CancellationToken ct)
        {
            return await _shopingCartRepository.VerifyItemExistsAsync(request, ct);
        }

        public async Task<IEnumerable<GetShopingCartResponse>> GetShoppingCartByUserAsync(GetShoppingCartByUserRequest request, CancellationToken ct)
        {
            return await _shopingCartRepository.GetShoppingCartByUserAsync(request, ct);
        }
    }
}
