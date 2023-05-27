using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanejaiFront.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanejaiFront.Pages.User
{
    public class Register : PageModel
    {
        [BindProperty]
        public UserModel NewUser { get; set; } = new();

        public Register () { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
