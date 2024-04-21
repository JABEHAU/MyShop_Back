using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Models;

namespace JADWARE.MyShop.API.Endpoints.Products
{
    public class GetCategories: EndpointWithoutRequest<IEnumerable<Category>>
    {
        private readonly IProductService _productService;
        public GetCategories(IProductService productService)
        {
            _productService = productService;
        }

        public override void Configure()
        {
            Post("Products/Categories");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = await _productService.GetCategories(ct);
            await SendOkAsync(response, ct);
        }
    }
}
