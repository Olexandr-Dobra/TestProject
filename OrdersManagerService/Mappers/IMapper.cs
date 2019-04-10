using OrdersManagerRepository;

namespace OrdersManagerService.Mappers
{
    public interface IMapper
    {
        OrderItem MapToDb(Models.OrderItem item);
        Models.OrderItem Map(OrderItem item);
    }
}
