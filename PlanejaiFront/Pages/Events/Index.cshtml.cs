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
                Id = 1,
                Name = "Campeonato de Bolinha de Gude",
                Description = "Um campeonato de bolinha de gude para voc� e sua fam�lia.", 
                StartDate = new DateTime(2023, 06, 10), 
                StartsAt = new DateTime(1, 1, 1, 9, 30, 0),
                Local = "Casa da M�e Joana",
                EndDate = new DateTime(2023, 06, 15), 
                EndsAt = new DateTime(1, 1, 1, 22, 30, 0),
                Organizer = new UserModel { Id = 1, Name = "Bruno", LastName = "Facundo" },
            });

            EventsList.Add(new EventModel
            {
                Id = 2,
                Name = "Campeonato de Futebol de Bot�o",
                Description = "Um campeonato de futebol de bot�o para voc� e sua fam�lia.",
                StartDate = new DateTime(2023, 06, 10),
                StartsAt = new DateTime(1, 1, 1, 9, 30, 0),
                Local = "UTFPR - Medianeira",
                EndDate = new DateTime(2023, 06, 15),
                EndsAt = new DateTime(1, 1, 1, 22, 30, 0),
                Organizer = new UserModel { Id = 1, Name = "Bruno", LastName = "Facundo" },
            });
        }
    }
}
