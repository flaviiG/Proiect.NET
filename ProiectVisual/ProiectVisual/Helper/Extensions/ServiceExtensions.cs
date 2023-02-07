using ProiectVisual.Repositories.MemberRepository;
using Microsoft.Extensions.DependencyInjection;
using ProiectVisual.Services.MemberService;
using ProiectVisual.Services.MemberServices;
using ProiectVisual.Helper.Seeders;
using ProiectVisual.Helper.Mapper;

namespace ProiectVisual.Helper.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMemberRepository, MemberRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
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
