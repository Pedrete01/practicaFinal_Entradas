using practicaFinal_Entradas.DbConnection;

namespace practicaFinal_Entradas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            Seed(host);
            host.Run();

            return;
        }

        private static void Seed(IHost builder)
        {
            var scopeFactory = builder.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory?.CreateScope())
            {
                var seeder = scope?.ServiceProvider.GetService<DbInitializer>();
                seeder?.SeedAsync().Wait();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetupConfiguration(HostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            builder.AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
        }
    }
}