using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.Users;

namespace JADWARE.MyShop.API.Endpoints.Users
{
    public class SendPasswordToUserEndpoint: Endpoint<SendPasswordToUserRequest, Boolean>
    {
        private readonly IUserService _userService;

        public SendPasswordToUserEndpoint(IUserService userService)
        {
            _userService= userService;
        }

        public override void Configure()
        {
            Post("Users/SendPassword");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SendPasswordToUserRequest request, CancellationToken ct)
        {
            var response = await _userService.SendPasswordByEmailAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
