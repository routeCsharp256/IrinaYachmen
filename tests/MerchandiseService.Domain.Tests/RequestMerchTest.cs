using System;
using System.Data.SqlTypes;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Domain.ValueObjects;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class RequestMerchTest
    {
        [Fact]
        public void IncreaseStockItemQuantity()
        {
            //Arrange 
            var requestMerch = new RequestMerch(
                new Sku(149568),
                new MerchPack(MerchPackType.StarterPack),
                new Employee(23),
                new Date(DateTime.Now),
                new Quantity(10),
                Status.Awaiting);

            var valueToIncrease = 10;
        
            //Act
            requestMerch.IncreaseQuantity(valueToIncrease);
        
            //Assert
            Assert.Equal(20, requestMerch.Quantity.Value);
        }
        
        [Fact]
        public void IncreaseQuantityNegativeValueSuccess()
        {
            //Arrange 
            //Arrange 
            var requestMerch = new RequestMerch(
                new Sku(149568),
                new MerchPack(MerchPackType.StarterPack),
                new Employee(23),
                new Date(DateTime.Now),
                new Quantity(10),
                Status.Awaiting);
            var valueToIncrease = -10;
            //Act
            
            //Assert
            Assert.Throws<Exception>(() => requestMerch.IncreaseQuantity(valueToIncrease));
        }
    }
}