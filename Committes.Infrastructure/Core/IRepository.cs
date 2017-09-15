using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Infrastructure.Core
{
    public interface IRepository<T> 
    {
        IQueryable<T> List { get; }
        T FindBy(int key);
        void Add(T item);
        void Remove(T item);
        void Remove(int item);
        void Update(T item);
        int Commit();

    }
}
