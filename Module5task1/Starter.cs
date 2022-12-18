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
        var userNotFound = await _userService.GetUserById(23);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
        var users = await _userService.CreateUserList(2);
        var usersDelay = await _userService.GetListUsersDelay(3);
        var userUpdate = await _userService.UpdateUserPut("morpheus", "zion resident", 2);
        var userDelete = await _userService.DeleteUserAsync(2);
        var resource = await _resourceService.GetResourceById(2);
        var resourceNotFound = await _resourceService.GetResourceById(23);
        await _resourceService.GetResourcePage(2);
        await _resourceService.GetResourcePage(3);
        var register = await _loginService.Register("eve.holt@reqres.in", "pistol");
        var registerFailed = await _loginService.Register("eve.holt@reqres.in", string.Empty);
        var login = await _loginService.Login("eve.holt@reqres.in", "cityslicka");
        var loginFailed = await _loginService.Login("peter@klaven", string.Empty);
    }
}