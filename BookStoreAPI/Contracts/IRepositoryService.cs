using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Contracts
{
    public interface IRepositoryService<T> where T : class
    {
        Task<bool> Create(T entity);
        Task<IList<T>> RetrieveAll();
        Task<T> Retrieve(int id);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }
}