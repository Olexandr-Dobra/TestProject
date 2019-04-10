using Microsoft.Extensions.DependencyInjection;
using OrdersManagerRepository;
using OrdersManagerRepository.Repositories;

namespace OrdersManagerService
{
    public class DependencyRegistrator
    {
        public static void Register(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddTransient<IOrderItemRepository, OrderItemRepository>();
            RepositoryRegistrator.Register(serviceCollection, connectionString);
        }

    }
}
