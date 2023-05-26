using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanejaiFront.Models;

namespace PlanejaiFront.Pages.Register
{
    public class Index : PageModel
    {
        public UserModel? NewUser { get; set; }

        public Index() { }

        public void OnGet()
        {
        }
    }
}
