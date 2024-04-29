using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Users;

namespace JADWARE.MyShop.API.Endpoints.Users
{
    public class GetUserByMailAndPassEndpoint: Endpoint<GetUserByMailAndPassRequest, User>
    {
        private readonly IUserService _userService;

        public GetUserByMailAndPassEndpoint(IUserService userService)
        {
            _userService = userService;
        }

        public override void Configure()
        {
            Post("Users/GetByMailAndPassword");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetUserByMailAndPassRequest request, CancellationToken ct)
        {
            var user = await _userService.GetUserByMailAndPasswordAsync(request, ct);
            await SendOkAsync(user, ct);
        }
    }
}
