using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IUserRepository
{
    Task<UserModel> GetAsync(int id);

    decimal GetBalance(int id);
}