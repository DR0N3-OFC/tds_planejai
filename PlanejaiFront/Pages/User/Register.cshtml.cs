using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PlanejaiFront.Models;
using PlanejaiFront.Models.APIConnection;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.Metadata;
using System.Text;

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
                return Page();

            try
            {
                NewUser.Password = Password;

                var httpClient = new HttpClient();
                var url = $"{APIConnection.URL}/Users/";

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                var jsonUser = JsonConvert.SerializeObject(NewUser);
                requestMessage.Content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(requestMessage);

                return RedirectToPage("/Events/Index");
            }
            catch (BadHttpRequestException)
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
