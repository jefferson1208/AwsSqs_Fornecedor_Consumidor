using AwsSqs.Consumidor.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AwsSqs.Consumidor
{
    class Program
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _provider;
        private Startup _app;
        public Program()
        {
            _services = new ServiceCollection();
        }
        static async Task Main(string[] args)
        {
            await new Program().IniciarPrograma();
        }

        private async Task IniciarPrograma()
        {
            Config();

            await _app.LerMensagensFila();
        }

        private void Config()
        {
            _services.ConfigServices();
            _provider = _services.BuildServiceProvider();

            _app = _provider.GetService<Startup>();
        }
    }
}
