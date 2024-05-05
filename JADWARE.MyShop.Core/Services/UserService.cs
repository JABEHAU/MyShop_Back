using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Domain.Models;
using JADWARE.MyShop.Domain.Requests.Users;

namespace JADWARE.MyShop.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Boolean> InsertUserAsync(InsertUserRequest request, CancellationToken ct)
        {
            return await _userRepository.InsertUserAsync(request, ct);
        }

        public async Task<Boolean> SendPasswordByEmailAsync(SendPasswordToUserRequest request, CancellationToken ct)
        {
            return await _userRepository.SendPasswordByEmailAsync(request, ct);
        }

        public async Task<Boolean> VerifyEmailExistsAsync(VerifyEmailExistsRequest request, CancellationToken ct)
        {
            return await _userRepository.VerifyEmailExistsAsync(request, ct);
        }

        public async Task<User> GetUserByMailAndPasswordAsync(GetUserByMailAndPassRequest request, CancellationToken ct)
        {
            return await _userRepository.GetUserByMailAndPasswordAsync(request, ct);
        }
    }
}
