﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnlineEdu.WebUI.DTOs.SubscribersDtos
{
    public class CreateSubscriberDto
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
