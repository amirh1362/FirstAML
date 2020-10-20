using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Model
{
    public class ShippingDetail
    {
        public ShippingDetail(Size parcelSize, decimal weight)
        {
            ParcelSize = parcelSize;
            Weight = weight;
        }
        public Size ParcelSize { get; set; }
        public decimal Weight { get; set; }
        public decimal Cost { get; set; }
    }
}
