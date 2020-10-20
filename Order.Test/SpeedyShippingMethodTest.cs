using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Order.Model;
using Order.Service;
using Xunit;
namespace Order.Test
{
    public class SpeedyShippingMethodTest
    {

        [Fact]
        public void Should_ReturnAdditionalRow_When_SpeedyIsApplied()
        {
            var orderLines = new List<UserOrderItem>()
            {
                new UserOrderItem(10)
            };
            var fastShipping = new FastShippingMethodService();
            ;
            var userService = new UserOrderService(orderLines, fastShipping);
            userService.ProcessOrder();
            Assert.Equal(userService.TotalCost, 10);
            Assert.Equal(userService.NumberOfLines(), 2);
        }

        [Fact]
        public void Should_ReturnAdditionalRow_When_SpeedyIsAppliedWithTwoRows()
        {
            var orderLines = new List<UserOrderItem>()
            {
                new UserOrderItem(10),
                new UserOrderItem(20)
            };
            var fastShipping = new FastShippingMethodService();
            ;
            var userService = new UserOrderService(orderLines, fastShipping);
            userService.ProcessOrder();
            Assert.Equal(userService.TotalCost, 30);
            Assert.Equal(userService.NumberOfLines(), 3);
        }
    }
}
