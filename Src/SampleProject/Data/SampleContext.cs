using Microsoft.EntityFrameworkCore;
using SampleProject.Models;

namespace SampleProject.Data;

public  class SampleContext : DbContext
{
    public virtual DbSet<ProductModel> Products { get; set; }
}