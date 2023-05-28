using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanejaiFront.Models;

namespace PlanejaiFront.Pages.Events
{
    public class Index : PageModel
    {
        [BindProperty]
        public List<EventModel> EventsList { get; set; } = new ();

        public void OnGet()
        {
            EventsList.Add(new EventModel 
            { 
                Name = "Campeonato de Bolinha de Gude",
                Description = "Um campeonato de bolinha de gude para você e sua família.", 
                StartDate = new DateTime(2023, 06, 10), 
                StartsAt = new DateTime(1, 1, 1, 9, 30, 0), 
                EndDate = new DateTime(2023, 06, 15), 
                EndsAt = new DateTime(1, 1, 1, 22, 30, 0) });

            EventsList.Add(new EventModel
            {
                Name = "Campeonato de Futebol de Botão",
                Description = "Um campeonato de futebol de botão para você e sua família.",
                StartDate = new DateTime(2023, 06, 10),
                StartsAt = new DateTime(1, 1, 1, 9, 30, 0),
                EndDate = new DateTime(2023, 06, 15),
                EndsAt = new DateTime(1, 1, 1, 22, 30, 0)
            });
        }
    }
}
