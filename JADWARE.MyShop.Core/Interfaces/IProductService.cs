using JADWARE.MyShop.Domain.Models;

namespace JADWARE.MyShop.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct);
        Task<IEnumerable<Category>> GetCategories(CancellationToken ct);
    }
}
