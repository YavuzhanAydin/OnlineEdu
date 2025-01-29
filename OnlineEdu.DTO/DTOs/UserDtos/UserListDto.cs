using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.UserDtos
{
    public class UserListDto
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }


    }
}
