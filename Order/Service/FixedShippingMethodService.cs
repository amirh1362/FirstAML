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
        private decimal AdditionalKg = 2;

        private UserOrderItem GetParcelCost(UserOrderItem userOrderItem)
        {
            decimal cost = 0;
            decimal maxWeight = 0;
            decimal defaultAdditionalCost = 2;
            switch (userOrderItem.ShippingDetail.ParcelSize)
            {
                case Size.Xll:
                    cost = 50;
                    maxWeight = 50;
                    defaultAdditionalCost = 1;
                    break;
                case Size.Xl:
                    cost = 25;
                    maxWeight = 10;
                    break;
                case Size.Large:
                    cost = 15;
                    maxWeight = 6;
                    break;
                case Size.Medium:
                    cost = 8;
                    maxWeight = 3;
                    break;
                case Size.Small:
                    cost = 3;
                    maxWeight = 1;
                    break;
            }
            userOrderItem.ShippingDetail.Cost = cost+ CalculateAdditionalCost(maxWeight, userOrderItem.ShippingDetail.Weight, defaultAdditionalCost);
            return userOrderItem;
        }

        private decimal CalculateAdditionalCost(decimal maxWeight, decimal weigth, decimal defaultAdditionalCost)
        {
            decimal difference = weigth - maxWeight;
            if (difference <= 0)
                return 0;
            return difference * defaultAdditionalCost;
        }
    }
}
