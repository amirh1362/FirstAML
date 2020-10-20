using System;
using System.Collections.Generic;
using System.Text;
using Order.Model;

namespace Order.Interface
{
    public interface IShippingMethod
    {
        List<UserOrderItem> Calculate(List<UserOrderItem> userOrderItem);
    }
    
    
}
