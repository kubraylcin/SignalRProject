﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(RegisterDto registerDto)
		{
			var appUser= new AppUser()
			{
				Name=registerDto.Name,
				Surname= registerDto.Surname,
				Email=registerDto.Email,
				UserName = registerDto.UserName

			};
			var result = await _userManager.CreateAsync(appUser,registerDto.Password); // ıdentityde yeni kullanıcı kaydetme creatteasync iki parametre alıyor appuser ve appuser password
            if (result.Succeeded)
            {
				return RedirectToAction("Index", "Login");
            }
			return View();
        }
	}
}
