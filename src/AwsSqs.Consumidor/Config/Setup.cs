using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;

namespace AwsSqs.Consumidor.Config
{
    public static class Setup
    {
        public static void ConfigServices(this IServiceCollection services)
        {
            services.AddSingleton<Startup>();
            services.AddSingleton<AmazonSQSClient>(new AmazonSQSClient(Amazon.RegionEndpoint.SAEast1));

        }
    }
}
