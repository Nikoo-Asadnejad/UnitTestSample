using Moq;
using SampleProject.Dtos;
using SampleProject.Interfaces;
using SampleProject.Models;
using SampleProject.Services.Product;
using Shouldly;

namespace Fundamental.Tests.Services._2.Product;

/// <summary>
/// Moq Set ups , Return func in moq
/// </summary>
public partial class ProductService_Tests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IEmailService> _emailServiceMoq;
    private readonly Mock<IUserRepository> _userRepositoryMoq;
    private readonly Mock<IOrderRepository> _orderRepositotyMoq;
    private ProductService _productService;
    private ProductModel _productResponse;
    private UserModel _userResponse;
    private decimal _userBalanceResposne;
    
    public ProductService_Tests()
    {
        _productResponse =  new(1, "test", 1000, 2);
        _userResponse = new(1, "nikoo", "asadnejad", "0021983781", "nikoo@gmail.com");
        _userBalanceResposne = 1000000;
        _productRepositoryMock = new();
        _productRepositoryMock.Setup(r => r.GetAsync(It.IsAny<int>()))
                              .ReturnsAsync(()=>_productResponse);
        
        _userRepositoryMoq = new();
        _userRepositoryMoq.Setup(u => u.GetAsync(It.IsAny<int>()))
                          .ReturnsAsync(() => _userResponse);
        _userRepositoryMoq.Setup(u => u.GetBalance(It.IsAny<int>())).Returns(() => _userBalanceResposne);
        
        
        _emailServiceMoq = new();
        _orderRepositotyMoq = new();
        
        _productService = new ProductService(_productRepositoryMock.Object,_emailServiceMoq.Object ,_userRepositoryMoq.Object, _orderRepositotyMoq.Object);

    }

    [Fact]
    public async Task GetAsync_ProductExist_ReturnsProductDto()
    {
        //Act
        ProductDto result = await _productService.GetAsync(1);
        
        //Assert
        Assert.Equal(1 , result.Id);
        
        //Assert by shouldy
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
    }
    
    [Fact]
    public async Task GetAsync_ProductDoesNotExist_ThrowsException()
    {
        //Arrange 
        _productResponse = null; //change func in setup to see error
        var func = async () => await _productService.GetAsync(1);

        //Assert
        await Assert.ThrowsAnyAsync<Exception>(func);

        //Assert by shouldy
        Should.Throw<Exception>(func);
    }
}