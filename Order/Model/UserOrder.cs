using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Model
{
    public enum Size
    {
        Small,Medium,Large,Xl
    }
    public class UserOrder
    {
        public UserOrder(Size parcelSize)
        {
            ParcelSize = parcelSize;
        }
        public Size ParcelSize { get; set; }

        public ShippingDetail ShippingDetail { get; set; }
    }
}
