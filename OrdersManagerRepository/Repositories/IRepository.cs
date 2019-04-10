using OrdersManagerRepository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManagerRepository.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task Create(TEntity model);
        Task Update(TEntity model);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> GetAllItems();
        Task<TEntity> Get(int id);
    }
}
