using Fundamental.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;
using SampleProject.Repositories;
using Shouldly;

namespace Fundamental.Tests.Repositories;

public sealed class ProductRepository_Tests
{
    private readonly IProductRepository _repository;
    private Mock<SampleContext> _contextMock;
    public ProductRepository_Tests()
    {
        _contextMock = new (); // should not be sealed
        _contextMock.Setup<DbSet<ProductModel>>(x => x.Products)
                    .ReturnsDbSet(ProductDataGenerator.GetSampleProducts());

        _repository = new ProductRepository(_contextMock.Object);
    }

    [Fact]
    public async Task Get_ProductExist_ReturnsProduct()
    {
        //act
        var product = await _repository.GetAsync(1);

        //assert
        product.ShouldNotBeNull();
        product.Id.ShouldBe(1);

    }
    
    [Fact]
    public async Task Get_ProductNotExist_ReturnsNull()
    {
        //act
        var product = await _repository.GetAsync(2000);

        //assert
        product.ShouldBeNull();

    }

    [Fact]
    public async Task Save_ModelIsNull_ThrowsException()
    {
        Should.Throw<ArgumentNullException>(() => _repository.Save(null));
        
        _contextMock.Verify(p=>p.Add(null) , Times.Never);
        _contextMock.Verify(p=>p.SaveChanges() , Times.Never);
    }
    
    [Fact]
    public async Task Save_WhenCalled_ProductShouldBeSaved()
    {
        //Arrange
        ProductModel productModel = new("Test", 4000, 20);
        _contextMock.Setup(c => c.SaveChanges())
                    .Returns(1)
                    .Callback(() => productModel.Id = 5);

        //Act
        bool result =_repository.Save(productModel);
        
        //Assert
        _contextMock.Verify(p=>p.Products.Add(It.IsAny<ProductModel>()) , Times.Once);
        _contextMock.Verify(p=>p.SaveChanges() , Times.AtLeastOnce);
        productModel.ShouldNotBeNull();
        productModel.Id.ShouldBeGreaterThan(0);
        result.ShouldBeTrue();
    }
}