using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Responses.Categories;

namespace JADWARE.MyShop.API.Endpoints.Categories
{
    public class GetCategoriesWithProductsEndpoint: EndpointWithoutRequest<IEnumerable<CategoryWithProductsResponse>>
    {
        private readonly ICategoriesService _categoriesService;

        public GetCategoriesWithProductsEndpoint(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public override void Configure()
        {
            Post("Categories/GetWithTopProducts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = await _categoriesService.GetWithTopProductsAsync(ct);
            await SendOkAsync(response, ct);
        }
    }
}