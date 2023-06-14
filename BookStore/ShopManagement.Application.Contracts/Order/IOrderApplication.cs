using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart);
        string PaymentSucceeded(long orderId, long refId);
        double GetAmountBy(long id);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        void Cancel(long id);
        List<OrderItemViewModel> GetItems(long orderId);
    }
}
