using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PlanejaiFront.Models;
using PlanejaiFront.Models.APIConnection;
using System.Text;

namespace PlanejaiFront.Pages.Events
{
    public class Create : PageModel
    {
        [BindProperty]
        public EventModel NewEvent { get; set; } = new();
        public UserModel Organizer { get; set; } = new();
        public bool DatesAreValid { get; set; }

        readonly HttpContext httpContext;
        public Create(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext!;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            DatesAreValid = NewEvent.DatesAreValid();

            if (!ModelState.IsValid || !DatesAreValid || 
                NewEvent.StartDate!.Value.Date + NewEvent.StartsAt!.Value.TimeOfDay < DateTime.Now ||
                NewEvent.EndDate!.Value.Date > NewEvent.StartDate!.Value.Date.AddDays(7))
            {
                if (!DatesAreValid)
                {
                    ModelState.AddModelError("DatesAreValid", "A data de encerramento deve ser posterior à data e horário de início.");
                }

                if ((NewEvent.StartDate!.Value.Date + NewEvent.StartsAt!.Value.TimeOfDay) < DateTime.Now)
                {
                    ModelState.AddModelError("DatesAreValid", "A data de início deve ser posterior à data e horário atual.");
                }

                if (NewEvent.EndDate!.Value.Date > NewEvent.StartDate!.Value.Date.AddDays(7))
                {
                    ModelState.AddModelError("DatesAreValid", "A duração do evento não pode ultrapassar uma semana.");
                }

                return Page();
            }

            NewEvent.OrganizerId = (int) httpContext.Session.GetInt32("UserID")!;

            var httpClient = new HttpClient();
            var url = $"{APIConnection.URL}/Events/";

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            var jsonEvent = JsonConvert.SerializeObject(NewEvent);
            requestMessage.Content = new StringContent(jsonEvent, Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Events/Index");
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();

                ModelState.AddModelError(string.Empty, errorResponse);

                return Page();
            }
        }
    }
}
