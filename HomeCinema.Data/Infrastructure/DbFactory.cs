using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure {
    public class DbFactory: Disposable, IDbFactory {
        private HomeCinemaContext m_dbContext;

        public HomeCinemaContext Init() {
            return m_dbContext ?? (m_dbContext = new HomeCinemaContext());
        }

        protected override void DisposeCore() {
            if (m_dbContext != null) {
                m_dbContext.Dispose();
                m_dbContext = null;
            }
        }
    }
}
