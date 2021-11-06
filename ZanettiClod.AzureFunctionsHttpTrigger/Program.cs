using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using ZanettiClod.AppCore.Interfaces.Data;
using ZanettiClod.AppCore.Interfaces.Services;
using ZanettiClod.AppCore.Services;
using ZanettiClod.Infrastructure.Data;

namespace ZanettiClod.AzureFunctionsHttpTrigger
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(opt =>
                {
                    opt.AddSingleton<IProductServices, ProductServices>();
                    opt.AddSingleton<IProductRepository, ProductRepository>();
                })
                .Build();

            host.Run();
        }
    }
}