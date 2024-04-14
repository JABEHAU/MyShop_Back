using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JADWARE.MyShop.Core
{
    public static class ApplicationRegisterServices
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHelloWorldService, HelloWorldService> ();
            return services;
        }
    }
}
