using Microsoft.EntityFrameworkCore;
using OrdersManagerRepository.Models;

namespace OrdersManagerRepository.DbContexts
{
    public class OrdersManagerContext : DbContext
    {
        public OrdersManagerContext(DbContextOptions<OrdersManagerContext> options)
            : base(options)
        {
        }

        public DbSet<OrderItem> OrderItem { get; set; }
       
    }
}
