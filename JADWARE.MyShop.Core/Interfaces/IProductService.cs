using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Products;
using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct);
        Task<IEnumerable<BasicProduct>> GetTopProductsByCategoryAsync(GetTopByCategoryRequest request, CancellationToken ct);
        Task<IEnumerable<BasicProduct>> GetAllByCategoryAsync(GetTopByCategoryRequest request, CancellationToken ct);
        Task<Product> GetProductAsync(GetProductRequest request, CancellationToken ct);
    }
}
