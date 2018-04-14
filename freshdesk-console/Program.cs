using System;
using System.Collections.Generic;
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
            var ticketRepository = new TicketRepository(new BaseApiClient("dotnetapiclient", "sddBnfd6ZOeXytWWVXGD"));
            //Task.FromResult(ticketRepository.Delete(45158));            
            var filters = new Dictionary<string, string>();
            filters.Add("filter", "new_and_my_open");
            var tickets = ticketRepository.Get(filters).Result;
            // var allTickets = ticketRepository.Get().Result;
            var contactRepository = new ContactRepository(new BaseApiClient("dotnetapiclient", "sddBnfd6ZOeXytWWVXGD"));
            var contacts = contactRepository.Get(null).Result;

            var contact = new Contact(){
                Name = "Contato teste",
                Address = "Rua teste",
                Email = "teste2@teste.com.br",
                JobTitle = "Web developer"
            };

            var insertedContact = contactRepository.Post(contact).Result;
            
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
