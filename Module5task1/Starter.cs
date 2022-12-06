using System.Threading.Tasks;
using Module5task1.Service.Abstractions;

namespace Module5task1;

public class Starter
{
    private readonly IUserService _userService;
    private readonly ILoginService _loginService;
    private readonly IResourceService _resourceService;

    public Starter(
        IUserService userService,
        ILoginService loginService,
        IResourceService resourceService)
    {
        _userService = userService;
        _loginService = loginService;
        _resourceService = resourceService;
    }

    public async Task Start()
    {
        var user = await _userService.GetUserById(2);
        var user1 = await _userService.CreateUser("morpheus", "leader", 32);
        var user2 = await _userService.CreateUser("john", "weak", 30);
        var user3 = await _userService.CreateUser("gnom", "strong", 10);
        var users = await _userService.CreateUserList(user1, user2, user3);
        var delete = await _userService.DeleteUserAsync(23);
        var update = await _userService.UpdateUserPut("michael", "manager", 2, 23);
        var register = await _loginService.Register("user@gmail.com", 12345);
        var login = await _loginService.Login("user@gmail.com", 12345);
        var resourceid = await _resourceService.GetResourceById(2);
        var resourcepage = await _resourceService.GetResourcePage(3);
    }
}