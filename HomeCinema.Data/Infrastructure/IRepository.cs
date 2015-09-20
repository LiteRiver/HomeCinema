using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure {
    public interface IRepository<T> where T : class, IEntityBase, new() {
        IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> Table { get; }

        T SingleById(int id);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);
    }
}
