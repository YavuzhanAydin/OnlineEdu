using Microsoft.AspNetCore.Identity;

using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);

        Task LoginOutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);
        
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<List<ResultUserDto>> Get4TeachersAsync();

        Task<List<AssignRoleDto>> GetUserForRoleAssign(int id);
        Task<List<ResultUserDto>> GetAllTeacherAsync();

        Task<int> GetTeacherCount();
    }
}
