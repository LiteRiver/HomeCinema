using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure {
    public class UnitOfWork: IUnitOfWork {
        private readonly IDbFactory m_dbFactory;

        private HomeCinemaContext m_dbContext;

        public UnitOfWork(IDbFactory dbFactory) {
            m_dbFactory = dbFactory;
        }

        public HomeCinemaContext DbContext {
            get { return m_dbContext ?? (m_dbContext = m_dbFactory.Init());}
        }

        public void Commit() {
            DbContext.Commit();
        }
    }
}
