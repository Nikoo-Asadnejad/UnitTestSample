using SampleProject.Models;

namespace Fundamental.Tests.TestData;

public static class ProductDataGenerator
{
    public static List<ProductModel> GetSampleProducts()
        => new()
        {
            new (1,"Phone",1200 ,10),
            new (2,"Laptop",1200 ,3),
            new (3,"Iphone",1500 ,5),
            new (4,"Watch",20000 ,30),
        };
}