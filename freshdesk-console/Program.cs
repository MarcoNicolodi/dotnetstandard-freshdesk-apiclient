using System;
using System.Threading.Tasks;
using Freshdesk.Entity;
using Freshdesk.Http;
using Freshdesk.Repository;

namespace Freshdesk.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            var ticketRepository = new TicketRepository(new BaseApiClient("qualyteam", "OWrhYypp8Tg9hTUZc2uN"));
            Task.FromResult(ticketRepository.Delete(45158));
            
            
            //var oneTicket = ticketRepository.Get(45152).Result;
            // var allTickets = ticketRepository.Get().Result;

            // var ticket = new Ticket();
            // ticket.Description = "dotnet standard cachorro";
            // ticket.Subject = "beiramar falou osama sou eu";
            // ticket.Email = "example@email.io";
            // ticket.Priority = TicketPriority.HIGH;
            // ticket.Status = TicketStatus.OPEN;
            // ticket.GroupId = 35000205192;
            // ticket.Type = "Bug Cliente";
            // var responseTicket = ticketRepository.Post(ticket).Result;


        }
    }
}
