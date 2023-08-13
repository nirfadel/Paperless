using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperless.Core.Services
{

    /// <summary>
    /// Singelton for HttpClient
    /// </summary>
    public abstract class BaseHttpService :IDisposable
    {
        private static object _locker = new object();
        private static volatile HttpClient _httpsClient;

        protected static HttpClient Client
        {
            get
            {
                if (_httpsClient == null)
                {
                    lock (_locker)
                    {
                        if (_httpsClient == null)
                        {
                            _httpsClient = new HttpClient();
                        }
                    }
                }

                return _httpsClient;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_httpsClient != null)
                {
                    _httpsClient.Dispose();
                }

                _httpsClient = null;
            }
        }
    }
}
