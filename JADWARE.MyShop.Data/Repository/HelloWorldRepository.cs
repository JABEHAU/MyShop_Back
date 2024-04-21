using JADWARE.MyShop.Core.Interfaces.Repository;

namespace JADWARE.MyShop.Data.Repository
{
    public class HelloWorldRepository: IHelloWorldRepository
    {
        public async Task<string> HelloWorldAsync(CancellationToken ct)
        {
            return "Hello World!";
        }

    }
}
