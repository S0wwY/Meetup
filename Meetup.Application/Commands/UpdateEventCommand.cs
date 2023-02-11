using MediatR;
using Meetup.Application.ViewModels.EventViewModels;

namespace Meetup.Application.Commands
{
    public class UpdateEventCommand : IRequest
    {
        public EventForUpdateViewModel Event { get; set; }
        public int Id { get; set; }
    }
}
