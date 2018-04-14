using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Freshdesk.Infrastructure;

namespace Freshdesk.Http
{
    public class BaseApiClient : IBaseApiClient
    {
        public BaseApiClient(string companyDomain, string apiKey)
        {
            ApiKey = apiKey;
            CompanyDomain = companyDomain;
        }

        public string ApiKey { get; set; }
        public string CompanyDomain { get; set; }
        private string ApiVersion { get; set; } = "v2";

        private string MountAuthorizationHeaderValue()
        {
            var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes($"{ApiKey}:X"));
            return $"Basic {authInfo}";
        }

        private string MountCallFullUrl(string uri)
        {
            return $"https://{CompanyDomain}.freshdesk.com/api/{ApiVersion}/{uri}";
        }

        public async Task<Stream> Get()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            client.DefaultRequestHeaders.Add("Authorization", MountAuthorizationHeaderValue());
            var finalUrl = MountCallFullUrl(null);

            return await client.GetStreamAsync(finalUrl);
        }

        public async Task<Stream> Get(string uri)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            client.DefaultRequestHeaders.Add("Authorization", MountAuthorizationHeaderValue());
            var finalUrl = MountCallFullUrl(uri);

            return await client.GetStreamAsync(finalUrl);
        }

        public async Task<Stream> Post(string uri, HttpContent content)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            client.DefaultRequestHeaders.Add("Authorization", MountAuthorizationHeaderValue());
            var finalUrl = MountCallFullUrl(uri);
            
            var response =  await client.PostAsync(finalUrl, content);
            if(!response.IsSuccessStatusCode){                
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Freshdesk api returned and {response.StatusCode} status code with following error: {error}");
            }
            var stream = new MemoryStream();
            stream.Position = 0;
            await response.Content.CopyToAsync(stream);
            return stream;            
        }

        public async Task Delete(string uri)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            client.DefaultRequestHeaders.Add("Authorization", MountAuthorizationHeaderValue());
            var finalUrl = MountCallFullUrl(uri);
            await client.DeleteAsync(finalUrl);
        }

        public async Task<Stream> Put(string uri, HttpContent content)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", MountAuthorizationHeaderValue());
            var finalUrl = MountCallFullUrl(uri);
            var response = await client.PutAsync(finalUrl, content);
            if(!response.IsSuccessStatusCode) {

            }
            var stream = new MemoryStream();
            stream.Position = 0;
            await response.Content.CopyToAsync(stream);
            return stream;
        }

        
    }
}