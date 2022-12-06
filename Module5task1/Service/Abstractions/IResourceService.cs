using System.Collections.Generic;
using System.Threading.Tasks;
using Module5task1.Dto.Response;

namespace Module5task1.Service.Abstractions;

public interface IResourceService
{
    Task<ResourceDto> GetResourceById(int id);
    Task<IReadOnlyList<ResourceDto>> GetResourcePage(int page);
}