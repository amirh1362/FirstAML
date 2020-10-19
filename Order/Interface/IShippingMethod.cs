using System;
using System.Collections.Generic;
using System.Text;
using Order.Model;

namespace Order.Interface
{
    public interface IShippingMethod
    {
        ShippingDetail Calculate(Model.UserOrder userOrder);
    }
    
    
}
