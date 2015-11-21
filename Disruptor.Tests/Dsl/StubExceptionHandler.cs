using System;

namespace Disruptor.Tests.Dsl
{
    public class StubExceptionHandler : IExceptionHandler
    {
        private StructWrapper<Threading.Volatile.Reference<Exception>> _exceptionHandled;

        public StubExceptionHandler(StructWrapper<Threading.Volatile.Reference<Exception>> exceptionHandled)
        {
            _exceptionHandled = exceptionHandled;
        }

        public void HandleEventException(Exception ex, long sequence, object evt)
        {
            _exceptionHandled.Value.WriteFullFence(ex);
        }

        public void HandleOnStartException(Exception ex)
        {
            _exceptionHandled.Value.WriteFullFence(ex);
        }

        public void HandleOnShutdownException(Exception ex)
        {
            _exceptionHandled.Value.WriteFullFence(ex);
        }
    }
}