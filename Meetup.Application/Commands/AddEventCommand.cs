using MediatR;
using Meetup.Application.ViewModels.EventViewModels;

namespace Meetup.Application.Commands
{
    public class AddEventCommand : IRequest
    {
        public EventForCreationViewModel Event { get; set; }
    }
}
