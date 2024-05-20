using JADWARE.MyShop.Core.Interfaces;
using JADWARE.MyShop.Core.Interfaces.Repository;
using JADWARE.MyShop.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JADWARE.MyShop.Core
{
    public static class ApplicationRegisterServices
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHelloWorldService, HelloWorldService> ();
            services.AddScoped<IProductService, ProductService> ();
            services.AddScoped<IUserService, UserService> ();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IShopingCartService, ShopingCartService>();
            services.AddScoped<ISalesService, SalesService> ();
            return services;
        }
    }
}
