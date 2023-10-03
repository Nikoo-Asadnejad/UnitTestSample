using Moq;
using SampleProject.Models;

namespace Fundamental.Tests.Services._2.Product;

public partial class ProductService_Tests
{
    [Fact]
    public async Task OrderAsync_ProductWasNull_ReturnsFalse()
    {
        //Arrange
        _productResponse = null;

        //Act
        var result = await _productService.OrderAsync(It.IsAny<int>(), It.IsAny<int>());
        
        //Assert 
        Assert.False(result.isSuccessfull);
    }

    [Fact]
    public async Task OrderAsync_UserWasNull_ReturnsFalse()
    {
        //Arrange
        _userResponse = null;

        //Act
        var result = await _productService.OrderAsync(It.IsAny<int>(), It.IsAny<int>());
        
        //Assert 
        Assert.False(result.isSuccessfull);
    }

    [Fact]
    public async Task OrderAsync_UserBalanceNotEnough_ReturnsFalse()
    {
        //Arrange
        _userBalanceResposne = 0;

        //Act
        var result = await _productService.OrderAsync(It.IsAny<int>(), It.IsAny<int>());
        
        //Assert 
        Assert.False(result.isSuccessfull);
    }

    [Fact]
    public async Task OrderAsync_InventoryNotEnough_ReturnsFalse()
    {
        //Arrange
        _productResponse.Inventory = 0;

        //Act
        var result = await _productService.OrderAsync(It.IsAny<int>(), It.IsAny<int>());
        
        //Assert 
        Assert.False(result.isSuccessfull);
    }

    [Fact]
    public async Task OrderAsync_WhenCalled_OrderShouldBeAdded()
    {
        //Arrange 
        _productResponse.Id = 1;
        _userResponse.Id = 2;
        //Act
        var result = await _productService.OrderAsync(1, 2);
        
        //Assert 
        _orderRepositotyMoq.Verify(o=> o.AddAsync(It.Is<OrderModel>(o=> o.ProductId == 1 && o.UserId==2)));
    }

    [Fact]
    public async Task OrderAsync_WhenCalled_EmailShouldBeSent()
    {
        //Act
        var result = await _productService.OrderAsync(It.IsAny<int>(), It.IsAny<int>());
        
        //Assert 
       _emailServiceMoq.Verify(e=> 
                                e.SendAsync(It.IsAny<string>(), _userResponse.Email , It.IsAny<string>(),It.IsAny<string>(),It.IsAny<CancellationToken>()));
    }

    [Fact]
    public async Task OrderAsync_WhenCalled_ShouldReturnSuccess()
    {
        //Act
        var result = await _productService.OrderAsync(It.IsAny<int>(), It.IsAny<int>());
        
        //Assert
        Assert.True(result.isSuccessfull);
    }
}