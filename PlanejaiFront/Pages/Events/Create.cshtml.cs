using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanejaiFront.Models;

namespace PlanejaiFront.Pages.Events
{
    public class Create : PageModel
    {
        [BindProperty]
        public EventModel NewEvent { get; set; } = new();

        public bool DatesAreValid { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            DatesAreValid = NewEvent.DatesAreValid();

            if (!ModelState.IsValid || !DatesAreValid)
            {
                if (!DatesAreValid)
                {
                    ModelState.AddModelError("DatesAreValid", "A data de encerramento deve ser posterior à data de início.");
                }

                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
