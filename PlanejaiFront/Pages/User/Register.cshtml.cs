using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanejaiFront.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanejaiFront.Pages.User
{
    [BindProperties]
    public class Register : PageModel
    {
        public UserModel NewUser { get; set; } = new();

        [Required(ErrorMessage = "Informe uma senha.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirme sua senha.")]
        [Compare("Password", ErrorMessage = "As senhas não são idênticas.")]
        public string? ConfirmPassword { get; set; }

        public Register () { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NewUser.Password = Password;

            return RedirectToPage("/Index");
        }
    }
}
