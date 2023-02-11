using Meetup.Data.Data;
using Meetup.Data.Interfaces;
using Meetup.Models;
using Microsoft.EntityFrameworkCore;

namespace Meetup.Data.Repositories
{
    public class OrganizerRepository : BaseRepository<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(DataContext context) : base(context)
        {
                
        }

        public async Task<IList<Organizer>> GetOrganizersByIdsAsync(IList<int> ids)
        {
            var organizers = await dataContext.Organizers.Where(o => ids.Contains(o.Id)).ToListAsync();
            
            return organizers;
        }
    }
}
