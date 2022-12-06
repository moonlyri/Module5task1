using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5task1.Config;
using Module5task1.Dto.Request;
using Module5task1.Dto.Response;
using Module5task1.Service.Abstractions;

namespace Module5task1.Service;

public class LoginService : ILoginService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<LoginService> _logger;
    private readonly ApiOption _options;
    private readonly string _login = "/api/login";

    public LoginService(
        IInternalHttpClientService client,
        IOptions<ApiOption> options,
        ILogger<LoginService> logger)
    {
        _httpClientService = client;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<LoginResponse> Register(string email, int password)
    {
        var result = await _httpClientService.SendAsync<LoginResponse,
            LoginRequest>(
            $"{_options.Host}{_login}",
            HttpMethod.Post,
            new LoginRequest()
            {
                Email = email,
                Password = password
            });
        if (result != null)
        {
            _logger.LogInformation("Register was successful");
        }
        else
        {
            _logger.LogWarning("Register failed");
        }

        return result;
    }

    public async Task<LoginResponse> Login(string email, int password)
    {
        var result = await _httpClientService.SendAsync<LoginResponse,
            LoginRequest>(
            $"{_options.Host}{_login}",
            HttpMethod.Post,
            new LoginRequest()
            {
                Email = email,
                Password = password
            });
        if (result != null)
        {
            _logger.LogInformation("Logging in was successful");
        }
        else
        {
            _logger.LogWarning("Logging in failed");
        }

        return result;
    }
}