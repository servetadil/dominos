
using Dominos.Core.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dominos.Core.Base
{
    public abstract class BaseService<T> : IDisposable, IBaseService<T>
        where T : BaseEntity
    {

        private IRepository<T> _baseRepository;

        protected IRepository<T> BaseRepository
        {
            get
            {
                return _baseRepository;
            }
        }


        public BaseService(IRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<T> GetAll()
        {
            return _baseRepository.Table;
        }

        //public IQueryable<T> Search(SearchArgs args)
        //{
        //    var query = _baseRepository.Table;

        //    if (args.SearchColumns.Any() && !args.SearchText.IsNullOrEmpty() && args.SearchText.Length >= 3)
        //    {
        //        foreach (var column in args.SearchColumns)
        //        {
        //            query = query.Where(String.Format("{0}.StartsWith(@0)", column), args.SearchText);
        //        }
        //    }


        //    if (!String.IsNullOrEmpty(args.OrderBy))
        //    {
        //        if (args.Direction)
        //            query = query.OrderBy(args.OrderBy);
        //        else
        //            query = query.OrderByDescending(args.OrderBy);
        //    }
        //    else
        //    {
        //        query = query.OrderBy(o => o.Id);
        //    }


        //    if (args.PageSize != 0)
        //        query = query.Paginate(args.PageIndex, args.PageSize);


        //    return query;
        //}

        public T GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public void Insert(T entity)
        {
            _baseRepository.Insert(entity);
        }

        public async Task InsertAsync(T entity)
        {
            await _baseRepository.InsertAsync(entity);
        }


        public void Delete(T entity)
        {
            _baseRepository.Delete(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _baseRepository.DeleteAsync(entity);
        }

        public void Update(T entity)
        {
            _baseRepository.Update(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _baseRepository.UpdateAsync(entity);
        }

        public int TotalCount()
        {
            return this.GetAll().Count();
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
