using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;

namespace CustomSearchEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    if (!ctx.HostingEnvironment.IsDevelopment())
                    {
                        var config = builder.Build();
                        var tokenProvider = new AzureServiceTokenProvider();

                        var kvClient = new KeyVaultClient((authority, resource, scope) =>
                            tokenProvider.KeyVaultTokenCallback(authority, resource, scope));

                        builder.AddAzureKeyVault(config["AzureKeyVault:BaseUrl"], kvClient,
                            new DefaultKeyVaultSecretManager());
                    }
                });
    }
}