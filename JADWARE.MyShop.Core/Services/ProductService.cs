using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Models;

namespace JADWARE.MyShop.Core.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct)
        {
            return await _productRepository.GetAllProductsAsync(ct);
        }

        public async Task<IEnumerable<Category>> GetCategories(CancellationToken ct)
        {
            return await _productRepository.GetCategories(ct);
        }
    }
}
