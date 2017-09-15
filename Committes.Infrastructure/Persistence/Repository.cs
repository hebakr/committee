using Committes.Infrastructure.Core;
using System.Data.Entity;
using System.Linq;

namespace Committes.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IQueryable<T> List
        {
            get
            {
                return _dbSet;
            }
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public T FindBy(int key)
        {
            return _dbSet.Find(key);
        }


        public void Remove(int item)
        {
            _dbSet.Remove(FindBy(item));
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Update(T item)
        {
            var original = FindBy(item.Id);
            _context.Entry(original).CurrentValues.SetValues(item);
        }
    }
}
