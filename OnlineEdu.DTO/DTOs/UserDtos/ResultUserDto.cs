using OnlineEdu.Entity.Entities;
using OnlineEdu.DTO.DTOs.TeacherSocialDtos;

namespace OnlineEdu.DTO.DTOs.UserDtos
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }

        public List<TeacherSocial> TeacherSocials { get; set; }

    }
}
