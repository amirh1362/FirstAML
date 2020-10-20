using System;
using System.Collections.Generic;
using System.Text;
using Order.Model;

namespace Order.Interface
{
    public interface IDiscountCalculator
    {
        List<UserOrderItem> Calculate(List<UserOrderItem> userOrderItem);

    }
}
