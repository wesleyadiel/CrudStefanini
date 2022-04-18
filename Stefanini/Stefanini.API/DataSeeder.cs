using Stefanini.Data;

namespace Stefanini.API
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<StefaniniDBContext>();
            context.Database.EnsureCreated();
        }
    }
}
