using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Models;

namespace JADWARE.MyShop.API.Endpoints.Categories
{
    public class GetCategoriesInOfferEndpoint:EndpointWithoutRequest<IEnumerable<Category>>
    {
        private readonly ICategoriesService _categoriesService;
        public GetCategoriesInOfferEndpoint(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public override void Configure()
        {
            Post("Categories/TopInOffer");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = await _categoriesService.GetTopInOfferAsync(ct);
            await SendOkAsync(response, ct);
        }
    }
}
