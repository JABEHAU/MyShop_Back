using JADWARE.MyShop.Core.Interfaces;
namespace JADWARE.MyShop.Core.Interfaces.Repository
{
    public interface IHelloWorldRepository
    {
        Task<string> HelloWorldAsync(CancellationToken ct);
    }
}
