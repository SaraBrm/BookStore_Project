using _0_Framework.Infrastucture;
using ShopManagement.Domain.OrderAgg;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository:RepositoryBase<long,Order>,IOrderRepository
    {
        private readonly ShopContext _shopContext;

        public OrderRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public double GetAmountBy(long id)
        {
            var order = _shopContext.Orders
                .Select(x => new { x.PayAmount, x.Id })
                .FirstOrDefault(x => x.Id == id);
            if (order != null)
                return order.PayAmount;
            return 0;
        }
    }
}
