using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Responses.Categories;

namespace JADWARE.MyShop.Core.Services
{
    public class CategoriesService: ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct)
        {
            return await _categoriesRepository.GetAllCategoriesAsync(ct);
        }

        public async Task<IEnumerable<Category>> GetTopInOfferAsync(CancellationToken ct)
        {
            return await _categoriesRepository.GetTopInOfferAsync(ct);
        }
        public async Task<IEnumerable<CategoryWithProductsResponse>> GetWithTopProductsAsync(CancellationToken ct)
        {
            return await _categoriesRepository.GetWithTopProductsAsync(ct);
        }
    }
}
