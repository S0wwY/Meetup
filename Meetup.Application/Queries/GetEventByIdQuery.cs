using MediatR;
using Meetup.Application.ViewModels.EventViewModels;

namespace Meetup.Application.Queries
{
    public class GetEventByIdQuery : IRequest<EventViewModel>
    {
        public int Id { get; set; }
    }
}
