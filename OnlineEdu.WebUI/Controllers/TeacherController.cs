﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Controllers
{
    public class TeacherController(IUserService _userService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var teachers = await _userService.GetAllTeacherAsync();
            return View(teachers);
        }
    }
}
