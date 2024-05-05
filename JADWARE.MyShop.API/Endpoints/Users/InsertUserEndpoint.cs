using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Domain.Requests.Users;

namespace JADWARE.MyShop.API.Endpoints.Users
{
    public class InsertUserEndpoint:Endpoint<InsertUserRequest, Boolean>
    {
        private readonly IUserService _userService;

        public InsertUserEndpoint(IUserService userService)
        {
            _userService = userService;
        }

        public override void Configure()
        {
            Post("Users/InsertUser");
            AllowAnonymous();
        }

        public override async Task HandleAsync(InsertUserRequest request, CancellationToken ct)
        {
            var response = await _userService.InsertUserAsync(request, ct);
            await SendOkAsync(response, ct);
        }
    }
}
