using Order.Interface;
using Order.Model;

namespace Order.Service
{
    public class FixedShippingMethodService : IShippingMethod
    {
        public ShippingDetail Calculate(UserOrder userOrder)
        {
            decimal cost = 0;
            switch (userOrder.ParcelSize)
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
            return new ShippingDetail(){ Cost = cost};
        }
    }
}
