using System;
using System.Collections.Generic;
using System.Text;
using Order.Interface;
using Order.Model;

namespace Order.Service
{
    public class UserOrderService: IUserOrderService
    {
        private readonly IShippingMethod _shipping;
        public UserOrderService(IShippingMethod shipping)
        {
            _shipping = shipping;
        }

        public IEnumerable<UserOrder> ProcessOrder(List<UserOrder> orders)
        {
            foreach (var order in orders)
            {
                order.ShippingDetail = _shipping.Calculate(order);
                yield return order;
            }
        }
    }
}
