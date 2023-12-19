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
    public void Save(ProductModel productModel)
    {
        _context.Products.AddAsync(productModel);
        _context.SaveChanges();
    }

    public async Task<ProductModel> GetAsync(int id)
    {
        return _context.Products.Where(p => p.Id == id)
                                 .FirstOrDefault();
    }
}