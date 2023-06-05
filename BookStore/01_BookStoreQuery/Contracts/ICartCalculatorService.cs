using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;

namespace _01_BookStoreQuery.Contracts
{
    public interface ICartCalculatorService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }

}
