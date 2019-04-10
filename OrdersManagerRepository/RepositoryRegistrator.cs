using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrdersManagerRepository.DbContexts;

namespace OrdersManagerRepository
{
    public static class RepositoryRegistrator
    {
        public static void Register(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<OrdersManagerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
