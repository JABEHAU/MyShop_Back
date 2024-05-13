using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Services;
using JADWARE.MyShop.Domain.Models;

namespace JADWARE.MyShop.API.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint: EndpointWithoutRequest<IEnumerable<Category>>
    {
        private readonly ICategoriesService _categoriesService;
        public GetAllCategoriesEndpoint(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        public override void Configure()
        {
            Post("Categories/GetAll");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = await _categoriesService.GetAllCategoriesAsync(ct);
            await SendOkAsync(response, ct);
        }
    }
}
