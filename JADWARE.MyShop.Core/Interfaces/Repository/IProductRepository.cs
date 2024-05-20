using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Products;
using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.Core.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct);
        Task<IEnumerable<BasicProduct>> GetTopProductsByCategoryAsync(int categoryId, CancellationToken ct);
        Task<IEnumerable<BasicProduct>> GetAllByCategoryAsync(int categoryId, CancellationToken ct);
        Task<Product> GetProductAsync(int productId, CancellationToken ct);
        Task<BasicProduct> GetBasicProductAsync(int productId, CancellationToken ct);
        Task<IEnumerable<BasicProduct>> SearchByFilter(SearchByFilterRequest request, CancellationToken ct);
    }
}
