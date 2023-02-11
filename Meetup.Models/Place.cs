namespace Meetup.Models
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }

        public virtual IList<Event> Events { get; set; }
    }
}
