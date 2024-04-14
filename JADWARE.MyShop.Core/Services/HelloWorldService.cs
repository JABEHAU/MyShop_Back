using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Interfaces.Repository;

namespace JADWARE.MyShop.Core.Services
{
    public class HelloWorldService: IHelloWorldService
    {
        private readonly IHelloWorldRepository _helloWorldRepository;
        public HelloWorldService(IHelloWorldRepository helloWorldRepository)
        {
            _helloWorldRepository = helloWorldRepository;
        }

        public async Task<string> HelloWorldAsync(CancellationToken ct)
        {
            return await _helloWorldRepository.HelloWorldAsync(ct);
        }
    }
}
