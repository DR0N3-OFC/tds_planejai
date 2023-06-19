using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PlanejaiFront.Models;
using PlanejaiFront.Models.APIConnection;
using System.ComponentModel.DataAnnotations;

namespace PlanejaiFront.Pages.User
{
    public class Profile : PageModel
    {
        [BindProperty]
        public UserModel? ExistingUser { get; set; }

        readonly HttpContext httpContext;
        public Profile (IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext!;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var httpClient = new HttpClient();
            var url = $"{APIConnection.URL}/Users/{httpContext.Session.GetInt32("UserID")}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var existingUser = JsonConvert.DeserializeObject<UserModel>(content);

                ExistingUser = existingUser;

                return Page();
            }

            return RedirectToPage("/Index");
        }

        public IActionResult EndSession()
        {
            httpContext.Session!.Clear();

            return RedirectToPage("/Index");
        }
    }
}
