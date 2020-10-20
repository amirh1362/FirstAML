using System.Collections.Generic;
using Order.Interface;
using Order.Model;

namespace Order.Service
{
    public class FixedShippingMethodService : IShippingMethod
    {
        public List<UserOrderItem> Calculate(List<UserOrderItem> userOrderItems)
        {

            foreach (var userOrderItem in userOrderItems)
            {
                GetParcelCost(userOrderItem);
            }

            return userOrderItems;
        }

        private UserOrderItem GetParcelCost(UserOrderItem userOrderItem)
        {
            decimal cost = 0;
            switch (userOrderItem.ShippingDetail.ParcelSize)
            {
                case Size.Xl:
                    cost = 25;
                    break;
                case Size.Large:
                    cost = 15;
                    break;
                case Size.Medium:
                    cost = 8;
                    break;
                case Size.Small:
                    cost = 3;
                    break;
            }

            userOrderItem.ShippingDetail.Cost = cost;
            return userOrderItem;
        }
    }
}
