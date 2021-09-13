using AwsSqs.Fornecedor.Config;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AwsSqs.Fornecedor
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
        static void Main(string[] args)
        {
            new Program().IniciarPrograma();
        }

        private void IniciarPrograma()
        {
            Config();

            _app.PublicarMensagemNaFila();
        }

        private void Config()
        {
            _services.ConfigServices();
            _provider = _services.BuildServiceProvider();

            _app = _provider.GetService<Startup>();
        }
    }
}
