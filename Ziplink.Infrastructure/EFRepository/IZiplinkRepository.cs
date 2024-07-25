using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ziplink.Infrastructure.EFRepository;

    public interface IZiplinkRepository<T>
    {
        Task Add(T entity);
        Task<IEnumerable<T>> Get();
        IQueryable<T> Get(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int Id);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);


        Task Save();
        void Delete(T entity);
        void Update(T entity);
    }

