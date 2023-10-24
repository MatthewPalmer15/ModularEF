using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Interfaces
{
    public interface IModularRepository<T> where T : class
    {

        IQueryable<T> All();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> SaveAsync();



    }
}
