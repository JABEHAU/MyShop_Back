using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Models;

namespace JADWARE.MyShop.API.Endpoints.Products
{
    public class GetAllProductsEndpoint: EndpointWithoutRequest<IEnumerable<Product>>
    {
        private readonly IProductService _productService;

        public GetAllProductsEndpoint(IProductService productService)
        {
            _productService = productService;
        }

        public override void Configure()
        {
            Post("Products/GetAll");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = await _productService.GetAllProductsAsync(ct);
            await SendOkAsync(response, ct);
        }
    }
}
