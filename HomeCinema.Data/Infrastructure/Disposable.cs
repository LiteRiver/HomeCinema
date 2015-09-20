using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure {
    public class Disposable: IDisposable {
        private bool m_disposed;

        ~Disposable() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (!m_disposed) {
                if (disposing) {
                    DisposeCore();
                }
                m_disposed = true;
            }            
        }

        protected void DisposeCore() {
            
        }
    }
}
