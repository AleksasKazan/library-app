using Microsoft.Extensions.DependencyInjection;

namespace VismaBookLibraryApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            var libraryApp = serviceProvider.GetService<LibraryApp>();

            libraryApp.StartAsync();
        }
    }
}
