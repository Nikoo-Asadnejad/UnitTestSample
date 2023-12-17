namespace SampleProject.Models;

public record ProductModel
{
    public ProductModel(int Id, string Name, decimal Price, int Inventory)
    {
        this.Id = Id;
        this.Name = Name;
        this.Price = Price;
        this.Inventory = Inventory;
    }

    public ProductModel(string Name, decimal Price, int Inventory)
    {
        this.Name = Name;
        this.Price = Price;
        this.Inventory = Inventory;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }

    public void Deconstruct(out int Id, out string Name, out decimal Price, out int Inventory)
    {
        Id = this.Id;
        Name = this.Name;
        Price = this.Price;
        Inventory = this.Inventory;
    }
}
