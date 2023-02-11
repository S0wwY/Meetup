using AutoMapper;
using MediatR;
using Meetup.Application.Commands;
using Meetup.Data.Interfaces;

namespace Meetup.Application.CommandsHandlers
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IOrganizerRepository organizerRepository)
        {
            _eventRepository = eventRepository;
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(request.Id);
            var organizers = await _organizerRepository.GetOrganizersByIdsAsync(request.Event.OrganizersIds);

            eventEntity.Organizers.Clear();

            foreach (var org in organizers)
            {
                eventEntity.Organizers.Add(org);
            }

            _mapper.Map(request.Event, eventEntity);

            _eventRepository.Update(eventEntity);
            await _eventRepository.SaveAsync();

            return Unit.Value;
        }
    }
}



