using SampleProject.Dtos;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services.Product;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository productRepository)
    {
        _repository = productRepository;
    }
    
    public async Task<ProductDto> GetAsync(int id)
    {
        ProductModel model =await _repository.GetAsync(id);
        if (model is null)
            throw new Exception("given id was not found");

        ProductDto dto = new(model.Id, model.Name, model.price);
        return dto;
    }
}