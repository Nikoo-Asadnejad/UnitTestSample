namespace SampleProject.Models;

public record UserModel
{
    public UserModel(int Id ,string Name, string LastName, string NationalCode, string Email)
    {
        this.Id = Id;
        this.Name = Name;
        this.LastName = LastName;
        this.NationalCode = NationalCode;
        this.Email = Email;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string Email { get; init; }

    public void Deconstruct(out int Id , out string Name, out string LastName, out string NationalCode, out string Email)
    {
        Id = this.Id;
        Name = this.Name;
        LastName = this.LastName;
        NationalCode = this.NationalCode;
        Email = this.Email;
    }
}