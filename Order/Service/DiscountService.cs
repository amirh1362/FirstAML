using System.Collections.Generic;
using Order.Interface;
using Order.Model;

namespace Order.Service
{
    public class DiscountService : IDiscountCalculator
    {
        public List<UserOrderItem> Calculate(List<UserOrderItem> userOrderItems)
        {

            return userOrderItems;
        }

        private int smallNumber = 0;
        private int meduimNumber = 0;
        private int orderNumber = 0;

        private UserOrderItem GetParcelCost(UserOrderItem userOrderItem)
        {
            ++orderNumber;

            if (userOrderItem.ShippingDetail.ParcelSize == Size.Small)
            {
                ++smallNumber;
                if (smallNumber == 4)
                {
                    userOrderItem.ShippingDetail.Cost = 0;
                }
            }
            if (userOrderItem.ShippingDetail.ParcelSize == Size.Small)
            {
                ++meduimNumber;
                if (meduimNumber == 3)
                {
                    userOrderItem.ShippingDetail.Cost = 0;
                }
            }
            if (orderNumber == 5)
            {
                userOrderItem.ShippingDetail.Cost = 0;
            }
            return userOrderItem;
        }
    }
}
