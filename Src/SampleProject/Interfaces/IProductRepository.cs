using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IProductRepository
{
    Task<ProductModel> GetAsync(int id);

    void Save(ProductModel productModel);
}