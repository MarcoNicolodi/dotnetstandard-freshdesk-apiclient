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
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly IBaseApiClient _client;
        private readonly string baseUri = "tickets";

        public TicketRepository(IBaseApiClient client)
        {
            _client = client;
        }

        public async Task<List<Ticket>> Get()
        {
            var resultStream = _client.Get(baseUri);
            var serializer = new DataContractJsonSerializer(typeof(List<Ticket>));
            return serializer.ReadObject(await resultStream) as List<Ticket>;
        }

        public async Task<Ticket> Get(int id)
        {
            var resultStream = _client.Get($"{baseUri}/{id}");
            //var reader = new StreamReader(await resultStream);
            //var text = reader.ReadToEnd();

            var serializer = new DataContractJsonSerializer(typeof(Ticket));
            
            return serializer.ReadObject(await resultStream) as Ticket;
        }

        public async Task<Ticket> Post(Ticket entity)
        {
            var serializer = new DataContractJsonSerializer(typeof(Ticket));
            
            var stream = new MemoryStream();
            serializer.WriteObject(stream, entity);
            stream.Position = 0;
            var streamReader = new StreamReader(stream);
            var json = streamReader.ReadToEnd();
            var encoding = new UTF8Encoding();
            var buffer = encoding.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var resultStream = await _client.Post(baseUri, byteContent);           
            resultStream.Position = 0;
            
            return serializer.ReadObject(resultStream) as Ticket;
        }

        public void Update(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            await _client.Delete($"tickets/{id}");
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
