﻿using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            return services
                .AddTransient<IFileClient, FileClient>()
                .AddSingleton<ILibraryRepository, LibraryRepository>();
        }

    }
}
