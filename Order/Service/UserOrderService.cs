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
        private readonly IDiscountCalculator _discountCalculator;

        private List<UserOrderItem> _orders;

        public decimal TotalCost { get; set; }
        public UserOrderService(List<UserOrderItem> orders,IShippingMethod shippingMethod, IDiscountCalculator discountCalculator)
        {
            _shippingMethod = shippingMethod;
            _orders = orders;
            _discountCalculator = discountCalculator;
        }

        public void ProcessOrder()
        {
            _shippingMethod.Calculate(_orders);
            _discountCalculator.Calculate(_orders);
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
