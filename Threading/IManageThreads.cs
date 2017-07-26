using System;

namespace Threading
{
    public interface IManageThreads
    {
        void Queue(object o);
        void ProcessQueue(Action<object> action, int maxThreads);
        int NumberThreadsRunning { get; }
        int MaxConcurrentThreads { get; }
        void RemoveThread();
    }
}
