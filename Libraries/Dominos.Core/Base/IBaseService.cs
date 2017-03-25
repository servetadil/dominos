using Dominos.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.Core.Base
{
    public interface IBaseService<T> : IDisposable
        where T : BaseEntity
    {
        IQueryable<T> GetAll();

        //IQueryable<T> Search(SearchArgs args);

        T GetById(int id);

        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        Task<T> GetByIdAsync(int id);

        Task InsertAsync(T entity);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);

        int TotalCount();
    }
}
