using OrdersManagerRepository.Models;

namespace OrdersManagerRepository
{
    public class Quantity : Entity
    {
        public int OrderItemId { get; set; }
        public int Weight { get; set; }
        public int Count { get; set; }
    }
}