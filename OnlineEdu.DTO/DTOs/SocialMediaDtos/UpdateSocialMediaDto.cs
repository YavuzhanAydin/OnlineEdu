﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.SocialMediaDtos
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
    }
}
