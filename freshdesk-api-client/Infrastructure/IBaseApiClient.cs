using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Freshdesk.Infrastructure
{
    public interface IBaseApiClient
    {
        string CompanyDomain { get; set; }
        string ApiKey { get; set; }
        Task<Stream> Get(string url, string queryString);
        Task<Stream> Post(string url, HttpContent content);
        Task<Stream> Put(string url, HttpContent content);
        Task Delete(string url);
    }
}