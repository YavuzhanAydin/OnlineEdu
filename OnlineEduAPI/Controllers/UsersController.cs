using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Concrete;
using OnlineEdu.DTO.DTOs.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Controllers
{
    [Authorize(Roles = "Admin,  Student, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager , IJwtService _jwtService,IMapper _mapper) : ControllerBase
    { 
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Bu Email Sistemde Kayıtlı Değildir");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded) 
            { 
            
                return BadRequest("Kullanıcı Adı veya Şifre Hatalı");

            }

            var token = await _jwtService.CreateTokenAsync(user);
            return Ok(token);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user,model.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                await _userManager.AddToRoleAsync(user, "Student");
                return Ok("Kullanıcı Kaydı Başarılı");

            }
            return BadRequest(ModelState);
        }
        [HttpGet("TeacherList")]
        public async Task<IActionResult> TeacherList()
        {
            var teacher = await _userManager.GetUsersInRoleAsync("Teacher");
            return Ok(teacher);

        }
        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            return Ok(students);

        }

        [HttpGet("Get4Teachers")]
        public async Task<IActionResult> Get4Teachers()
        {
            var users = await _userManager.Users.Include(x => x.TeacherSocials).ToListAsync();
            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Wait(2000)).OrderByDescending(x => x.Id).Take(4).ToList();
            return Ok(teachers);

        }



    }
}
