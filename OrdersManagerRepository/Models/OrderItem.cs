using OrdersManagerRepository.Models;

namespace OrdersManagerRepository
{
    public class OrderItem : Entity
    { 
        public string Name { get; set; }
        public Quantity Quantity { get; set; }
        public int Status { get; set; }

    }
}
