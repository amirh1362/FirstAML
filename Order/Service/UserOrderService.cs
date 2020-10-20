using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order.Interface;
using Order.Model;

namespace Order.Service
{
    public class UserOrderService: IUserOrderService
    {
        private readonly IShippingMethod _shippingMethod;

        private List<UserOrderItem> _orders;

        public decimal TotalCost { get; set; }
        public UserOrderService(List<UserOrderItem> orders,IShippingMethod shippingMethod)
        {
            _shippingMethod = shippingMethod;
            _orders = orders;
        }

        public void ProcessOrder()
        {
            _orders =_shippingMethod.Calculate(_orders);
            this.TotalCost = TotalShippingCost(_orders.ToList());
        }


        private decimal TotalShippingCost(List<UserOrderItem> orders)
        {
            decimal totalCost = 0m;
            foreach (var order in orders)
            {
                totalCost += order.GetShippinhCost();
            }
            return totalCost;
        }

        public int NumberOfLines()
        {
            return _orders.Count;
        }
    }
}
