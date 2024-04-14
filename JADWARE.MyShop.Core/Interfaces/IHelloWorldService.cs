namespace JADWARE.MyShop.Core.Interfaces
{
    public interface IHelloWorldService
    {
        Task<string> HelloWorldAsync(CancellationToken ct);
    }
}
