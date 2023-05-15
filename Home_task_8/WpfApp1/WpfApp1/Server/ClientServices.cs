using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Server
{
    static class ClientServices
    {
        public static async void StartClient()
        {
            IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(services => { services.AddHostedService<Worker>(); })
            .Build();

            await host.RunAsync();
        }
    }
}
