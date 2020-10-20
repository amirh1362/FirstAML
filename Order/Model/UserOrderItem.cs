using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Model
{
    public enum Size
    {
        None,Small,Medium,Large,Xl,Xll
    }
    public class UserOrderItem
    {
        public UserOrderItem()
        {
        }

        public UserOrderItem(decimal itemCost)
        {
            this.ItemCost = itemCost;
        }
        public string OrderNumber { get; set; }

        public decimal ItemCost{ get; set; }

        public ShippingDetail ShippingDetail { get; set; }

        public decimal GetCost()
        {
            return ItemCost+(ShippingDetail?.Cost??0);
        }
        public decimal GetShippinhCost()
        {
            return (ShippingDetail?.Cost ?? 0);
        }

    }
}
