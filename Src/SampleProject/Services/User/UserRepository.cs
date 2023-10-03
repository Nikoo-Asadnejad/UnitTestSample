using SampleProject.Data;
using SampleProject.Models;

namespace SampleProject.Services.User;

public class UserRepository
{
    private readonly Context _context;
    public UserRepository(Context context)
    {
        _context = context;
    }
    public async Task<(int?, string)> AddAsync(UserModel user)
    {
        bool isExist = _context.Users.Any(u => u.NationalCode == user.NationalCode);
        if (isExist)
            return (null, "User exists");
        
        _context.Users.Add(user);
       await _context.SaveChangesAsync();
       return (user.Id, "Ok");
    }
}