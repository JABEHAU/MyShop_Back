using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Responses.Categories;

namespace JADWARE.MyShop.Core.Interfaces.Repository
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct);
        Task<IEnumerable<Category>> GetTopInOfferAsync(CancellationToken ct);
        Task<IEnumerable<CategoryWithProductsResponse>> GetWithTopProductsAsync(CancellationToken ct);
    }
}
