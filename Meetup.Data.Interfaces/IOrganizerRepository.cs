using Meetup.Models;

namespace Meetup.Data.Interfaces
{
    public interface IOrganizerRepository : IBaseRepository<Organizer>
    {
        Task<IList<Organizer>> GetOrganizersByIdsAsync(IList<int> ids);
    }
}
