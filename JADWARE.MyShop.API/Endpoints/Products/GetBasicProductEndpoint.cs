using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.Products;
using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.API.Endpoints.Products
{
    public class GetBasicProductEndpoint:Endpoint<GetProductRequest, BasicProduct>
    {
        private readonly IProductService _productService;

        public GetBasicProductEndpoint(IProductService productService)
        {
            _productService = productService;
        }

        public override void Configure()
        {
            Post("Products/GetBasicProduct");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetProductRequest request, CancellationToken ct)
        {
            BasicProduct response = await _productService.GetBasicProductAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
