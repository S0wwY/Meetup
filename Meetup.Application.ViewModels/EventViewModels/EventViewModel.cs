
namespace Meetup.Application.ViewModels.EventViewModels
{
    public class EventViewModel
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }

        public IList<string> Organizers { get; set; }
        public string Place { get; set; }
    }
}
