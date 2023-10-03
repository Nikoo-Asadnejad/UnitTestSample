using Microsoft.EntityFrameworkCore;
using SampleProject.Models;

namespace SampleProject.Data;

public class Context  : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    
}

