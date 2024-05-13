using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.Products;
using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.API.Endpoints.Products
{
    public class GetTopProductsByCategoryEndpoint:Endpoint<GetTopByCategoryRequest, IEnumerable<BasicProduct>>
    {
        private readonly IProductService _productService;
        public GetTopProductsByCategoryEndpoint(IProductService productService)
        {
            _productService = productService;
        }

        public override void Configure()
        {
            Post("Products/TopByCategory");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetTopByCategoryRequest request, CancellationToken ct)
        {
            var response = await _productService.GetTopProductsByCategoryAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
