using AutoMapper;
using MediatR;
using Meetup.Application.Commands;
using Meetup.Data.Interfaces;
using Meetup.Models;

namespace Meetup.Application.CommandsHandlers
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;

        public AddEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IOrganizerRepository organizerRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _organizerRepository = organizerRepository;
        }

        public async Task<Unit> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var organizers = await _organizerRepository.GetOrganizersByIdsAsync(request.Event.OrganizersIds);

            var eventEntity = _mapper.Map<Event>(request.Event);
            eventEntity.Organizers = organizers;

            _eventRepository.Insert(eventEntity);
            await _eventRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
