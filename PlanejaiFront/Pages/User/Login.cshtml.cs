using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanejaiFront.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanejaiFront.Pages.User
{
    public class Login : PageModel
    {
        public UserModel? ExistingUser { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Informe um e-mail válido.")]
        public string? Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Informe uma senha.")]
        public string? Password { get; set; }

        public Login () { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || ExistingUser == null)
            {
                if (ExistingUser == null)
                {
                    ModelState.AddModelError("ExistingUser", "Dados inválidos. Confira os dados inseridos e tente novamente.");
                }
                return Page();
            }

            return RedirectToPage("/Events/Index");
        }
    }
}
