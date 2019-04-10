using Microsoft.EntityFrameworkCore;
using OrdersManagerRepository.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManagerRepository.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly OrdersManagerContext ordersContext;

        public OrderItemRepository(OrdersManagerContext ordersContext) : base(ordersContext)
        {
            this.ordersContext = ordersContext;
        }

        public new async Task<IEnumerable<OrderItem>> GetAllItems()
        {
            var allItems = await ordersContext.Set<OrderItem>().Include(x => x.Quantity).ToListAsync();

            return allItems;
        }
        

        public new async Task<OrderItem> Get(int id)
        {
            return await ordersContext.Set<OrderItem>().Include(x => x.Quantity).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task ClearList()
        {
            var allItems = await GetAllItems();
            ordersContext.OrderItem.RemoveRange(allItems);
            ordersContext.SaveChanges();
        }
    }
}
