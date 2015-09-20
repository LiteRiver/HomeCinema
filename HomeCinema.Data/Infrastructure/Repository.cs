using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HomeCinema.Data.Infrastructure {
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new() {
        private HomeCinemaContext m_dbContext;

        public Repository(IDbFactory dbFactory) {
            DbFactory = dbFactory;
        }

        protected IDbFactory DbFactory {
            get;
            private set;
        }

        protected HomeCinemaContext DbContext {
            get { return m_dbContext ?? (m_dbContext = DbFactory.Init());}
        }

        public IQueryable<T> Include(params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties) {
            var query = Table;
            foreach (var prop in includeProperties) {
                query = query.Include(prop);
            }

            return query;
        }

        public IQueryable<T> Table {
            get { return DbContext.Set<T>(); }
        }

        public T SingleById(int id) {
            return Table.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate) {
            return Table.Where(predicate);
        }

        public void Add(T entity) {
            var entry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }

        public void Edit(T entity) {
            var entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity) {
            var entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Deleted;
        }
    }
}
