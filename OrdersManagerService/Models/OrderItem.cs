namespace OrdersManagerService.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Weight { get; set; }
        public int QuantityId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
