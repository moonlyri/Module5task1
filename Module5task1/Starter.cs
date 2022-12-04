using System.Threading.Tasks;
using Module5task1.Service.Abstractions;

namespace Module5task1;

public class Starter
{
    private readonly IUserService _userService;

    public Starter(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Start()
    {
        var user = await _userService.GetUserById(2);
        var user1 = await _userService.CreateUser("morpheus", "leader", 32);
        var user2 = await _userService.CreateUser("john", "weak", 30);
        var user3 = await _userService.CreateUser("gnom", "strong", 10);
        var users = await _userService.CreateUserList(user1, user2, user3);
        var delete = await _userService.DeleteUserAsync("id");
    }
}