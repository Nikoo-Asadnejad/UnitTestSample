using Moq;
using SampleProject.Dtos;
using SampleProject.Interfaces;
using SampleProject.Models;
using SampleProject.Services.Product;

namespace Fundamental.Tests.Services._2.Product;

/// <summary>
/// Moq Set ups , Return func in moq
/// </summary>
public class ProductService_Tests
{
    private Mock<IProductRepository> _productRepositoryMock;
    private ProductService _productService;
    private ProductModel _repositoryResponse;
    public ProductService_Tests()
    {
        _repositoryResponse =  new(1, "test", 1000);;
        
        _productRepositoryMock = new();
        _productRepositoryMock.Setup(r => r.GetAsync(It.IsAny<int>()))
                              .ReturnsAsync(()=>_repositoryResponse);
        
        _productService = new ProductService(_productRepositoryMock.Object);

    }

    [Fact]
    public async Task GetAsync_ProductExist_ReturnsProductDto()
    {
        //Act
        ProductDto result = await _productService.GetAsync(1);
        
        //Assert
        Assert.Equal(1 , result.Id);
    }
    
    [Fact]
    public async Task GetAsync_ProductDoesNotExist_ThrowsException()
    {
        //Arrange 
        _repositoryResponse = null; //change func in setup to see error
        var func = async () => await _productService.GetAsync(1);

        await Assert.ThrowsAnyAsync<Exception>(func);
    }
}