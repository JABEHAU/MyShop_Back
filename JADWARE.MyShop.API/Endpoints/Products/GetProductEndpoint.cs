using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Products;

namespace JADWARE.MyShop.API.Endpoints.Products
{
    public class GetProductEndpoint: Endpoint<GetProductRequest, Product>
    {
        private readonly IProductService _productService;

        public GetProductEndpoint(IProductService productService)
        {
            _productService = productService;
        }

        public override void Configure()
        {
            Post("Products/GetProduct");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetProductRequest request, CancellationToken ct)
        {
            Product response = await _productService.GetProductAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
