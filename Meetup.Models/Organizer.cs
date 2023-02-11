namespace Meetup.Models
{
    public class Organizer : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Event> Events { get; set; }
    }
}
