using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5task1.Config;
using Module5task1.Dto;
using Module5task1.Dto.Request;
using Module5task1.Dto.Response;
using Module5task1.Service.Abstractions;

namespace Module5task1.Service;

public class UserService : IUserService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly HttpClient _client;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApi = "api/users/";
    private readonly List<UserRequest> _users;

    public UserService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger,
        List<UserRequest> users,
        HttpClient client)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
        _users = users;
        _client = client;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>($"{_options.Host}{_userApi}{id}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation("User with id = {Id} was found", result.Data.Id);
        }

        return result?.Data;
    }

    public async Task<UserResponse> CreateUser(string name, string job, int age)
    {
        var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
            $"{_options.Host}{_userApi}",
            HttpMethod.Post,
            new UserRequest()
            {
                Job = job,
                Name = name,
                Age = age
            });

        if (result != null)
        {
            _logger.LogInformation("User with id = {Id} was created", result.Id);
        }

        return result;
    }

    public async Task<UserResponse> CreateUserList(UserResponse user1, UserResponse user2, UserResponse user3)
    {
        var user = new UserRequest();
        var result = await _httpClientService.SendListAsync<UserResponse, UserRequest>(
            $"{_options.Host}{_userApi}",
            HttpMethod.Post,
            new List<UserDto>()
            {
                Capacity = 3,
            });
        _users.Add(user);

        if (result != null)
        {
            _logger.LogInformation("Users with id = {Id} were created", result.Id);
        }

        return result;
    }

    public async Task<BaseResponse<UserDto>> DeleteUserAsync(string id)
    {
        var delete = await _client.DeleteAsync(id);
        var result =
            await _httpClientService.SendAsync<BaseResponse<UserDto>, object>(
                $"{_options.Host}{_userApi}{id}",
                HttpMethod.Post);
        _logger.LogInformation("User with id = {Id} was deleted", id);
        return result;
    }
}