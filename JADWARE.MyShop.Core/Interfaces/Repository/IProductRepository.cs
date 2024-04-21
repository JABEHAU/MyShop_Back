using JADWARE.MyShop.Domain.Models;

namespace JADWARE.MyShop.Core.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct);
        Task<IEnumerable<Category>> GetCategories(CancellationToken ct);
    }
}
