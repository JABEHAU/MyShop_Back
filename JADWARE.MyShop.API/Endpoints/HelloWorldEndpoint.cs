using JADWARE.MyShop.Core.Interfaces;
namespace JADWARE.MyShop.API.Endpoints
{
    public class HelloWorldEndpoint: EndpointWithoutRequest<String>
    {
        private readonly IHelloWorldService _helloWorldService;
        public HelloWorldEndpoint(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        public override void Configure()
        {
            Post("HelloWorld");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = await _helloWorldService.HelloWorldAsync(ct);
            await SendOkAsync(response, ct);
        }
    }
}
