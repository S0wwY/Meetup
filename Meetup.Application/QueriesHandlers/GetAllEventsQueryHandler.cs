using AutoMapper;
using MediatR;
using Meetup.Application.Queries;
using Meetup.Application.ViewModels.EventViewModels;
using Meetup.Data.Interfaces;

namespace Meetup.Application.QueriesHandlers
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IList<EventViewModel>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IList<EventViewModel>> Handle(GetAllEventsQuery request, CancellationToken token)
        {
            var events = await _eventRepository.GetAllAsync();
            var result = _mapper.Map<IList<EventViewModel>>(events);

            return result;
        }
    }
}
