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

        // public async Task<string> GetOne()
        // {
        //     var client = new HttpClient();

        //     var url = "https://qualyteam.freshdesk.com/api/v2/tickets/4";
        //     var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes($"{this._apiKey}:X"));
        //     //client.DefaultRequestHeaders.Accept()
        //     client.DefaultRequestHeaders.Accept.Clear();
        //     client.DefaultRequestHeaders.Accept.Add(
        //         new MediaTypeWithQualityHeaderValue("application/json"));
        //     client.DefaultRequestHeaders.Add("Authorization", $"Basic {authInfo}");
        //     //client.DefaultRequestHeaders.Add("Content-type", "application/json");
        //     var response = await client.GetStringAsync(url);
        //     return response;
        // }

        // public static async Task<List<GithubRepo>> ProcessRepositories()
        // {
        //     var client = new HttpClient();
        //     client.DefaultRequestHeaders.Accept.Clear();
        //     client.DefaultRequestHeaders.Accept.Add(
        //         new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        //     client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        //     var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        //     var serializer = new DataContractJsonSerializer(typeof(List<GithubRepo>));
        //     return serializer.ReadObject(await streamTask) as List<GithubRepo>;
        // }
    }
}
