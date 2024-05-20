using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Products;
using JADWARE.MyShop.Domain.Responses.Products;

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

        public async Task<IEnumerable<BasicProduct>> GetTopProductsByCategoryAsync(GetTopByCategoryRequest request, CancellationToken ct)
        {
            return await _productRepository.GetTopProductsByCategoryAsync(request.CategoryId, ct);
        }

        public async Task<IEnumerable<BasicProduct>> GetAllByCategoryAsync(GetTopByCategoryRequest request, CancellationToken ct)
        {
            return await _productRepository.GetAllByCategoryAsync(request.CategoryId, ct);
        }

        public async Task<Product> GetProductAsync(GetProductRequest request, CancellationToken ct)
        {
            return await _productRepository.GetProductAsync(request.ProductId, ct);
        }
        public async Task<BasicProduct> GetBasicProductAsync(GetProductRequest request, CancellationToken ct)
        {
            return await _productRepository.GetBasicProductAsync(request.ProductId, ct);
        }

        public async Task<IEnumerable<BasicProduct>> SearchByFilter(SearchByFilterRequest request, CancellationToken ct)
        {
            return await _productRepository.SearchByFilter(request, ct);
        }
    }
}
