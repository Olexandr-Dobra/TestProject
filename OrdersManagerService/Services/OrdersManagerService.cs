using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdersManagerService.Mappers;
using OrdersManagerService.Models;

namespace OrdersManagerService.Services
{
    public class OrdersManagerService : IOrdersManagerService
    {
        private readonly OrdersManagerRepository.Repositories.IOrderItemRepository repository;
        private readonly IMapper mapper;

        public OrdersManagerService(OrdersManagerRepository.Repositories.IOrderItemRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task Create(OrderItem order)
        {
            await repository.Create(mapper.MapToDb(order));
        }

        public async Task Delete(int id)
        {
            var order = await repository.Get(id);
            order.Status = (int)OrderStatus.Deleted;
            await repository.Update(order);
        }

        public async Task<OrderItem> GetAsync(int id)
        {
            return mapper.Map(await repository.Get(id));
        }
        public async Task<IEnumerable<OrderItem>> GetAllItemsAsync()
        {
            var result = (await repository.GetAllItems()).Select(x => mapper.Map(x));

            return result;
        }

        public async Task Update(OrderItem order)
        {
            await repository.Update(mapper.MapToDb(order));
        }

        public Task ClearList()
        {
            throw new System.NotImplementedException();
        }
    }
}
