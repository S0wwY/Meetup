using AutoMapper;
using MediatR;
using Meetup.Application.Queries;
using Meetup.Application.ViewModels.EventViewModels;
using Meetup.Data.Interfaces;

namespace Meetup.Application.QueriesHandlers
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventViewModel>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventByIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventViewModel> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(request.Id);

            return _mapper.Map<EventViewModel>(eventEntity);
        }
    }
}
