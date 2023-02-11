using AutoMapper;
using Meetup.Application.ViewModels.EventViewModels;
using Meetup.Models;

namespace Meetup.Application.ViewModels.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EventForCreationViewModel, Event>()
                .ForMember(a => a.Name, opt => opt.MapFrom(a => a.EventName))
                .ForMember(a => a.Time, opt => opt.MapFrom(t => DateTime.Parse(t.Date + " " + t.Time)));

            CreateMap<Event, EventViewModel>()
                .ForMember(a => a.EventName, opt => opt.MapFrom(a => a.Name))
                .ForMember(a => a.Place, opt => opt.MapFrom(a => a.Place.Name))
                .ForMember(a => a.Time, opt => opt.MapFrom(a => a.Time.ToString("yyyy-MM-dd HH:mm")))
                .ForMember(a => a.Organizers, opt => opt.MapFrom(a => a.Organizers.Select(y => y.Name).ToArray()));

            CreateMap<EventForUpdateViewModel, Event>()
                .ForMember(a => a.Name, opt => opt.MapFrom(a => a.Name))
                .ForMember(a => a.Time, opt => opt.MapFrom(t => DateTime.Parse(t.Date + " " + t.Time)));
        }
    }
}
