using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PlanejaiFront.Models;
using PlanejaiFront.Models.APIConnection;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

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
            var httpClient = new HttpClient();
            var url = $"{APIConnection.URL}/Users/{Email}/{Password}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            var existingUser = JsonConvert.DeserializeObject<UserModel>(content);

            ExistingUser = existingUser;

            if (!ModelState.IsValid || ExistingUser == null)
            {
                if (ModelState.IsValid && ExistingUser == null)
                {
                    ModelState.AddModelError("ExistingUser", "Dados inválidos. Confira os dados inseridos e tente novamente.");
                }
                return Page();
            }

            return RedirectToPage("/Events/Index");
        }
    }
}
