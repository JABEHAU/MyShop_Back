using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.Users;

namespace JADWARE.MyShop.API.Endpoints.Users
{
    public class VerifyEmailExistsEndpoint: Endpoint<VerifyEmailExistsRequest, Boolean>
    {
        private readonly IUserService _userService;
        public VerifyEmailExistsEndpoint(IUserService userService)
        {
            _userService= userService;
        }

        public override void Configure()
        {
            Post("Users/VerifyEmailExists");
            AllowAnonymous();
        }

        public override async Task HandleAsync(VerifyEmailExistsRequest request, CancellationToken ct)
        {
            var response = await _userService.VerifyEmailExistsAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
