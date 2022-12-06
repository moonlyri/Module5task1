using System.Threading.Tasks;
using Module5task1.Dto.Response;

namespace Module5task1.Service.Abstractions;

public interface ILoginService
{
    Task<LoginResponse> Register(string email, int password);
    Task<LoginResponse> Login(string email, int password);
}