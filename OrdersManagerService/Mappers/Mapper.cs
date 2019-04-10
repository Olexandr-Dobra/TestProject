using OrdersManagerRepository;

namespace OrdersManagerService.Mappers
{
    public class Mapper : IMapper
    {
        public OrderItem MapToDb(Models.OrderItem item)
        {
            return new OrderItem
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = new Quantity
                {
                    Id = item.QuantityId,
                    Count = item.Count,
                    Weight = item.Weight
                },
                Status = (int)item.Status
            };
        }

        public Models.OrderItem Map(OrderItem item)
        {
            return new Models.OrderItem
            {
                Name = item.Name,
                Count = item.Quantity.Count,
                Weight = item.Quantity.Weight,
                Status = (Models.OrderStatus)item.Status,
                Id = item.Id,
                QuantityId = item.Quantity.Id
            };
        }
    }
}
