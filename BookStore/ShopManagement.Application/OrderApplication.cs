using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApplication(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public long PlaceOrder(Cart cart)
        {
            throw new System.NotImplementedException();
        }
    }
}
