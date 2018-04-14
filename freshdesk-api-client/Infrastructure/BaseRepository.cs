using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Freshdesk.Infrastructure {
    public abstract class BaseRepository<T> : IRepository<T>  where T : class {
        protected readonly string _resourceUri;
        protected readonly IBaseApiClient _apiClient;
        public BaseRepository(string resourceUri, IBaseApiClient apiClient)
        {
            _resourceUri = resourceUri;
            _apiClient = apiClient;
        }

        public async Task Delete(int id)
        {
            await _apiClient.Delete($"{_resourceUri}/{id}");
        }

        public async Task<List<T>> Get()
        {
            var resultStream = _apiClient.Get(_resourceUri);
            var serializer = new DataContractJsonSerializer(typeof(List<T>));
            return serializer.ReadObject(await resultStream) as List<T>;
        }

        public async Task<T> Get(int id)
        {
            var resultStream = _apiClient.Get($"{_resourceUri}/{id}");
            var serializer = new DataContractJsonSerializer(typeof(T));            
            return serializer.ReadObject(await resultStream) as T;
        }

        public async Task<T> Post(T entity)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            
            var stream = new MemoryStream();
            serializer.WriteObject(stream, entity);
            stream.Position = 0;
            var streamReader = new StreamReader(stream);
            var json = streamReader.ReadToEnd();
            var encoding = new UTF8Encoding();
            var buffer = encoding.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var resultStream = await _apiClient.Post(_resourceUri, byteContent);           
            resultStream.Position = 0;
            
            return serializer.ReadObject(resultStream) as T;
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}