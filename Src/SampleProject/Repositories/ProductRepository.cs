using Microsoft.EntityFrameworkCore;
using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly SampleContext _context;

    public ProductRepository(SampleContext context)
    {
        this._context = context;
    }
    public bool Save(ProductModel productModel)
    {
        if (productModel is null)
            throw new ArgumentNullException();
        
        _context.Products.Add(productModel);
        return _context.SaveChanges() is 1;
    }

    public async Task<ProductModel?> GetAsync(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        return product;
    }
}