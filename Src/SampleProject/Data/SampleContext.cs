using Microsoft.EntityFrameworkCore;
using SampleProject.Models;

namespace SampleProject.Data;

public sealed class SampleContext : DbContext
{
    public DbSet<ProductModel> Products { get; set; }
}