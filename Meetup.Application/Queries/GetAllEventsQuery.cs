using MediatR;
using Meetup.Application.ViewModels.EventViewModels;

namespace Meetup.Application.Queries
{
    public class GetAllEventsQuery : IRequest<IList<EventViewModel>>
    {
        public GetAllEventsQuery()
        {
            
        }
    }
}
