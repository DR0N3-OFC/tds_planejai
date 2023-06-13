using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlanejaiFront.Models;

namespace PlanejaiFront.Pages.Events
{
    public class Details : PageModel
    {
        [BindProperty]
        public EventModel? Event { get; set; }
        public List<EventModel> EventsList { get; set; } = new();
        public List<GuestModel> GuestList { get; set; } = new();
        
        public void OnGet(int? id)
        {
            GuestList.Add(new GuestModel { Id = 1, Name = "Bruno", LastName = "Facundo", Email = "email@email.com", PhoneNumber = "12345-6789", Event = Event });
            GuestList.Add(new GuestModel { Id = 2, Name = "Luccas", LastName = "Facundo", Email = "email@email.com", PhoneNumber = "12345-6789", Event = Event });
            GuestList.Add(new GuestModel { Id = 1, Name = "Giglioli", LastName = "Facundo", Email = "email@email.com", PhoneNumber = "12345-6789", Event = Event });
            GuestList.Add(new GuestModel { Id = 1, Name = "Eder", LastName = "Facundo", Email = "email@email.com", PhoneNumber = "12345-6789", Event = Event });

            EventsList.Add(new EventModel
            {
                Id = 1,
                Name = "Campeonato de Bolinha de Gude",
                Description = "Um campeonato de bolinha de gude para você e sua família.",
                StartDate = new DateTime(2023, 06, 10),
                StartsAt = new DateTime(1, 1, 1, 9, 30, 0),
                Local = "Casa da Mãe Joana",
                EndDate = new DateTime(2023, 06, 15),
                EndsAt = new DateTime(1, 1, 1, 22, 30, 0),
                Organizer = new UserModel { Id = 1, Name = "Bruno", LastName = "Facundo" },
            });

            EventsList.Add(new EventModel
            {
                Id = 2,
                Name = "Campeonato de Futebol de Botão",
                Description = "Um campeonato de futebol de botão para você e sua família.",
                StartDate = new DateTime(2023, 06, 10),
                StartsAt = new DateTime(1, 1, 1, 9, 30, 0),
                Local = "UTFPR - Medianeira",
                EndDate = new DateTime(2023, 06, 15),
                EndsAt = new DateTime(1, 1, 1, 22, 30, 0),
                Organizer = new UserModel { Id = 1, Name = "Bruno", LastName = "Facundo" },
            });

            Event = EventsList.FirstOrDefault(e => e.Id == id);
        }
    }
}
