using MediatR;
using Meetup.Application.Commands;
using Meetup.Application.Exceptions;
using Meetup.Data.Interfaces;
using Meetup.Models;

namespace Meetup.Application.CommandsHandlers
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventForDelete = await _eventRepository.GetByIdAsync(request.Id);

            if (eventForDelete == null || eventForDelete.Id != request.Id)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            _eventRepository.Delete(eventForDelete);
            await _eventRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
