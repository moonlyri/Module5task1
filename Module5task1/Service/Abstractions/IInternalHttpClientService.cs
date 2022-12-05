using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Module5task1.Dto;

namespace Module5task1.Service.Abstractions;

public interface IInternalHttpClientService
{
    Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class;
}