namespace Meetup.Models
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }

        public virtual IList<Organizer> Organizers { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
    }
}
