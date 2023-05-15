//Directly the implementation Anonymous Pipes for Local Interprocess Communication
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace exercise_b.Server
{
    internal static class ServerServices
    {
        public static void StartServer()
        {
            IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(services => { services.AddHostedService<Worker>(); })
            .Build();
            host.RunAsync();
        }
    }
}
