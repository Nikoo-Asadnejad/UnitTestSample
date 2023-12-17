using Moq;
using SampleProject.Dtos;
using SampleProject.Models;
using Shouldly;

namespace Fundamental.Tests.Services._2.Product;

public partial class ProductService_Tests
{
    [Fact]
    public async Task AddAsync_ProductWasNull_ThrowException()
    {

        //Act
        var func = async () => await _productService.AddAsync(null);
        
        //Assert  
        Should.Throw<ArgumentNullException>(func);
    }
    

    [Fact]
    public async Task AddAsync_WhenCalled_SaveShouldBeAdded()
    {
        //Arrange 
        ProductDto productDto = new(1 , "Sth" , 2300);
        
        //Act
         await _productService.AddAsync(productDto);
        
        //Assert 
        _productRepositoryMock.Verify(o=> o.Save(It.Is<ProductModel>
                                                (o=> o.Name == productDto.Name && o.Price==productDto.Price)),Times.Once);
    }

  
}