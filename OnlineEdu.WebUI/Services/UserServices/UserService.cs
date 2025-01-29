using Microsoft.AspNetCore.Identity;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultUserDto>> Get4TeachersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultUserDto>> GetAllTeacherAsync()
        {
            throw new NotImplementedException();

        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
		{
            return await _client.GetFromJsonAsync<List<UserViewModel>>("roleAssigns");

		}

        public async Task<int> GetTeacherCount()
        {
            throw new NotImplementedException();
        }


        public async Task<List<AssignRoleDto>> GetUserForRoleAssign(int id)
        {
            return await _client.GetFromJsonAsync<List<AssignRoleDto>>("roleAssigns/" + id);

        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();

        }

        public async Task LoginOutAsync()
        {
            throw new NotImplementedException();

        }

     
    }
}
