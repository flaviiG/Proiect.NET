using ProiectVisual.Repositories.MemberRepository;
using Microsoft.Extensions.DependencyInjection;
using ProiectVisual.Services.MemberService;
using ProiectVisual.Services.MemberServices;
using ProiectVisual.Helper.Seeders;
using ProiectVisual.Helper.Mapper;
using ProiectVisual.Services.UserService;
using ProiectVisual.Repositories.UserRepository;

namespace ProiectVisual.Helper.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IUserRepository, UserRepository>();
 
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMemberService, MemberService>();
            
            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<MemberSeeder>();
            return services;
        }

    }
}
