
namespace Meetup.Application.ViewModels.EventViewModels
{
    public class EventForUpdateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int[] OrganizersIds { get; set; }
        public int PlaceId { get; set; }
    }
}
