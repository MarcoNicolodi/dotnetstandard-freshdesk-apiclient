using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Freshdesk.Entity;
using Freshdesk.Infrastructure;

namespace Freshdesk.Repository
{
    public class TicketRepository : BaseRepository<Ticket>,  IRepository<Ticket>
    {
        public TicketRepository(IBaseApiClient client) : base("tickets", client)
        {
        }
    }
}
