using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freshdesk.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> Get(Dictionary<string, string> queryString);
        Task<T> Get(int id, Dictionary<string, string> queryString);
        Task<T> Post(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}