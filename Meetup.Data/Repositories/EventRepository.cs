using Meetup.Data.Data;
using Meetup.Data.Interfaces;
using Meetup.Models;

namespace Meetup.Data.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(DataContext context) : base(context)
        {
            
        }
    }
}
