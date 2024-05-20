using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.Domain.Responses.ShopingCart
{
    public class GetShopingCartResponse
    {
        public int ItemId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public BasicProduct ProductDetail { get; set; }
    }
}
