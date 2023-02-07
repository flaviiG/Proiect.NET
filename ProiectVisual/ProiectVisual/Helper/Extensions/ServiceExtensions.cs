using ProiectVisual.Repositories.MemberRepository;
using Microsoft.Extensions.DependencyInjection;
using ProiectVisual.Services.MemberService;
using ProiectVisual.Services.MemberServices;

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
    }
}
