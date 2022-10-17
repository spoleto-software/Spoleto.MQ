using System;
using Spoleto.MQ.Options;
using EasyNetQ;

namespace Spoleto.MQ.Subscriber
{
    public class EasyRabbitSubscribeService : IDisposable, IEasyRabbitSubscribeService
    {
        private readonly IMqOption _settings;
        private readonly IBus _bus;

        public EasyRabbitSubscribeService(IMqOption settings)
        {
            _settings = settings;
            _bus = RabbitHutch.CreateBus($"host={_settings.Host};username={settings.Username};password={settings.Password};prefetchcount=1");
        }

        public IBus Bus => _bus;

        #region Dispose

        private bool _disposed = false;

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

        #endregion
    }
}
