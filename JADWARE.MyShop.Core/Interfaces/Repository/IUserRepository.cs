using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Users;

namespace JADWARE.MyShop.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByMailAndPasswordAsync(GetUserByMailAndPassRequest request, CancellationToken ct);
        Task<Boolean> SendPasswordByEmailAsync(SendPasswordToUserRequest request, CancellationToken ct);
    }
}
