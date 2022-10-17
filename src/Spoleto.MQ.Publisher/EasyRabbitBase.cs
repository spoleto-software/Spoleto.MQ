using System;
using Spoleto.MQ.Options;
using EasyNetQ;

namespace Spoleto.MQ.Publisher
{
    public abstract class EasyRabbitBase : IDisposable
    {
        private readonly IMqOption _settings;
        private readonly IBus _bus;

        private bool _disposed = false;

        protected EasyRabbitBase(IMqOption settings)
        {
            _settings = settings;
            _bus = RabbitHutch.CreateBus($"host={_settings.Host};username={settings.Username};password={settings.Password};prefetchcount=1");
        }

        protected IBus Bus => _bus;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _bus.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
