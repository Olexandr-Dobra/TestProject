using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManagerRepository.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task ClearList();
    }
}
