using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using SampleProject.Data;
using SampleProject.Models;
using SampleProject.Services.User;

namespace Fundamental.Tests.Services.User;
/// <summary>
/// Moq Ef Context : Moq.EntityFrameworkCore
/// </summary>
public class UserRepository_Tests
{
    private Mock<Context> _contextMoq;
    private readonly UserRepository _userRepository;
    private UserModel _userModel;
    public UserRepository_Tests()
    {
        
        _userModel = new UserModel(1, "nikoo", "asadnejad,", "0021983781");
        _contextMoq = new();
        _contextMoq.SetupGet<DbSet<UserModel>>(c => c.Users)
                   .ReturnsDbSet(new List<UserModel>()
                   {
                       _userModel,
                       new UserModel(2, "sara", "asadnejad", "123487889")
                   });
        
        _userRepository = new(_contextMoq.Object);
    }

    [Fact]
    public async Task AddAsync_UserExist_ReturnsNullIdAndError()
    {
        //Act
        (int? , string) result = await _userRepository.AddAsync(_userModel);
        
        //Assert 
        Assert.Null(result.Item1);
        Assert.Contains("duplicate", result.Item2);
    }
    
}