using CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreLayer.DTOs.Users;
using System.ComponentModel.DataAnnotations;
using CoreLayer.Utilities;

namespace Blog.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        #region Properties

        [Display(Name = "نام کابری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Username { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Fullname { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} معتبر نیست")]
        public string Password { get; set; }

        #endregion

        public RegisterModel(IUserService userService)
        {
            this._userService = userService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var result = _userService.RegisterUser(new UserRegisterDto()
            {
                Username = Username,
                Fullname = Fullname,
                Password = Password
            });

            if(result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("Username", result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
