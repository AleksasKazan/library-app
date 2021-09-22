using System;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;

namespace VismaBookLibraryApp
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services
                .AddPersistence()
                .AddDomain();
            //services.AddTransient<IFileClient, FileClient>();
            //services.AddSingleton<ILibraryRepository, LibraryRepository>();
            //services.AddSingleton<ILibraryService, LibraryService>();

            services.AddSingleton<LibraryApp>();

            return services.BuildServiceProvider();
        }
    }
}
