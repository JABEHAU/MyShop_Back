using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.Products;
using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.API.Endpoints.Products
{
    public class SearchProductByFilterEndpoint:Endpoint<SearchByFilterRequest, IEnumerable<BasicProduct>>
    {
        private readonly IProductService _productService;

        public SearchProductByFilterEndpoint(IProductService productService)
        {
            _productService = productService;
        }

        public override void Configure()
        {
            Post("Products/searchByFilter");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SearchByFilterRequest request, CancellationToken ct)
        {
            var response = await _productService.SearchByFilter(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
