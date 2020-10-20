using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Model
{
    public class ShippingDetail
    {
        public Size ParcelSize { get; set; }
        public decimal Cost { get; set; }
    }
}
