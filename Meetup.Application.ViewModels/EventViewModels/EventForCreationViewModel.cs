
namespace Meetup.Application.ViewModels.EventViewModels
{
    public class EventForCreationViewModel
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }

        public IList<int> OrganizersIds { get; set; }
        public int PlaceId { get; set; }
    }
}
