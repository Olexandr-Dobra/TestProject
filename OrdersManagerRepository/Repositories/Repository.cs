using Microsoft.EntityFrameworkCore;
using OrdersManagerRepository.DbContexts;
using OrdersManagerRepository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManagerRepository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly OrdersManagerContext ordersContext;

        public Repository(OrdersManagerContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }

        public async Task Create(TEntity model)
        {
            await ordersContext.Set<TEntity>().AddAsync(model);
            await ordersContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            ordersContext.Set<TEntity>().Remove(entity);
            await ordersContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await ordersContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllItems()
        {
            return await ordersContext.Set<TEntity>().ToListAsync();
        }

        public async Task Update(TEntity model)
        {
            ordersContext.Set<TEntity>().Update(model);
            await ordersContext.SaveChangesAsync();
        }
    }
}
