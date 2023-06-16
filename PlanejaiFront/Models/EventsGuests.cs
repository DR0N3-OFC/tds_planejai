namespace PlanejaiFront.Models
{
    public class EventsGuests
    {
        public int EventId { get; set; }
        public EventModel? Event { get; set; }
        public int GuestId { get; set; }
        public GuestModel? Guest { get; set; }
    }
}
