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
        public void Should_ReturnExpectedCost_When_FixDeliverCost(Size size,decimal expectedValue)
        {
            var fixedShipping = new FixedShippingMethodService();
            ShippingDetail shippingDetail = fixedShipping.Calculate(new UserOrder()
            {
                ParcelSize = size
            });
            Assert.Equal(shippingDetail.Cost,expectedValue);
        }
    }
}
