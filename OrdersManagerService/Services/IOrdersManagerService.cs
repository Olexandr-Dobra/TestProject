using OrdersManagerService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManagerService.Services
{
    public interface IOrdersManagerService
    {
        Task<IEnumerable<OrderItem>> GetAllItemsAsync();
        Task Create(OrderItem order);
        Task Update(OrderItem order);
        Task Delete(int id);
        Task<OrderItem> GetAsync(int id);
        Task ClearList();

    }
}
