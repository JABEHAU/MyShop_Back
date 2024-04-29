using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace JADWARE.MyShop.Data
{
    public static class InfrastructureRegisterServices
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddScoped<IHelloWorldRepository, HelloWorldRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}