using Microsoft.Extensions.DependencyInjection;

namespace Domain.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services.AddSingleton<ILibraryService, LibraryService>();
        }
    }
}
