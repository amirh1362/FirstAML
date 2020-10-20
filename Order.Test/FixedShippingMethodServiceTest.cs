using System.Collections.Generic;
using Order.Interface;
using Order.Model;
using Order.Service;
using Xunit;
namespace Order.Test
{
    public class FixedShippingMethodServiceTest
    {
        [Theory]
        [InlineData(Size.Small,3)]
        [InlineData(Size.Medium,8)]
        [InlineData(Size.Large,15)]
        [InlineData(Size.Xl,25)]
        public void Should_ReturnExpectedCost_When_FixDeliverCostAndNoWeight(Size size,decimal expectedValue)
        {
            var fixedShipping = new FixedShippingMethodService();
            var userItems = new List<UserOrderItem>() {new UserOrderItem() { ShippingDetail = new ShippingDetail(size,0) { ParcelSize = size } }};
            var userService = new UserOrderService(userItems, fixedShipping,new DiscountService());
            userService.ProcessOrder();
            Assert.Equal(userService.TotalCost,expectedValue);
        }

        [Theory]
        [InlineData(Size.Small,2, 5)]
        [InlineData(Size.Medium,3, 8)]
        [InlineData(Size.Large,8, 19)]
        [InlineData(Size.Xl,11, 27)]
        [InlineData(Size.Xll, 100, 100)]

        public void Should_ReturnExpectedCost_When_FixDeliverCostWithWeight(Size size, decimal weigth, decimal expectedValue)
        {
            var fixedShipping = new FixedShippingMethodService();
            var userItems = new List<UserOrderItem>() { new UserOrderItem() { ShippingDetail = new ShippingDetail(size, weigth) } };
            var userService = new UserOrderService(userItems, fixedShipping, new DiscountService());
            userService.ProcessOrder();
            Assert.Equal(userService.TotalCost, expectedValue);
        }


    }
}
