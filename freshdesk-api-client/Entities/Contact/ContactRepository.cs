using Freshdesk.Entity;
using Freshdesk.Infrastructure;

namespace Freshdesk.Repository 
{
    public class ContactRepository : BaseRepository<Contact>
    {
        public ContactRepository(IBaseApiClient apiClient) : base("contacts", apiClient)
        {
        }
    }
}