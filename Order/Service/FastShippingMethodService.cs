using Order.Interface;
using Order.Model;
using System.Collections.Generic;
using System.Threading;

namespace Order.Service
{
    public class FastShippingMethodService : IShippingMethod
    {
        public List<UserOrderItem> Calculate(List<UserOrderItem> userOrderItems)
        {
            decimal cost = 0;
            foreach (var userOrderItem in userOrderItems)
            {
                cost += userOrderItem.GetCost();
            }

            var userItem = new UserOrderItem(cost)
            {
                ShippingDetail = new ShippingDetail()
                {
                    Cost = cost
                }
            };
            userOrderItems.Add(userItem);
            return userOrderItems;
        }
    }
}
