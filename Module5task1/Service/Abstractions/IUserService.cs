using System.Threading.Tasks;
using Module5task1.Dto;
using Module5task1.Dto.Response;

namespace Module5task1.Service.Abstractions;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);
    Task<UserResponse> CreateUser(string name, string job, int age);
    Task<UserResponse> CreateUserList(UserResponse user1, UserResponse user2, UserResponse user3);
    Task<bool> DeleteUserAsync(int id);
    Task<UserResponse> UpdateUserPut(string name, string job, int id, int age);
}