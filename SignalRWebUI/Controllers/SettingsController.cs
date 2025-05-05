using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Surname = values.Surname;
            userEditDto.Email = values.Email;
            userEditDto.Name = values.Name;
            userEditDto.UserName = values.UserName;
            return View(userEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.Email = userEditDto.Email;
                user.Surname=userEditDto.Surname;
                user.UserName = userEditDto.UserName;
                user.PasswordHash= _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
                 await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Category");
            }
            return View(userEditDto);
        }
    }
}
