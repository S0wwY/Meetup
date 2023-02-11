using MediatR;

namespace Meetup.Application.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public int Id { get; set; }
    }
}
