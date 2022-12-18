using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module5task1.Config;
using Module5task1.Dto.Response;
using Module5task1.Service.Abstractions;
using IResourceService = Module5task1.Service.Abstractions.IResourceService;

namespace Module5task1.Service;

public class ResourceService : IResourceService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<ResourceService> _logger;
    private readonly ApiOption _options;
    private readonly string _sharedResourceApi = "api/unknown/";
    public ResourceService(
        IInternalHttpClientService httpClientService,
        ILogger<ResourceService> logger,
        IOptions<ApiOption> options)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<ResourceDto> GetResourceById(int id)
    {
        var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>(
            $"{_options.Host}{_sharedResourceApi}{id}",
            HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation("Resource with id = {Id} was found", result.Data.Id);
        }

        return result?.Data;
    }

    public async Task<ListResponse<ResourceDto>> GetResourcePage(int page)
    {
        var result = await _httpClientService.SendAsync<ListResponse<ResourceDto>, object>(
            $"{_options.Host}{_sharedResourceApi}{page}",
            HttpMethod.Get);

        if (result != null)
        {
            _logger.LogInformation($"Resource page was found!");
        }
        else
        {
            _logger.LogInformation("Resources with page = {Page} was not found", page);
        }

        return result;
    }
}