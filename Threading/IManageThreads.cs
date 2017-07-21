namespace Threading
{
    public interface IManageThreads
    {
        void Queue(object o);
        void ProcessQueue();
        int NumberThreadsRunning { get; }
        int MaxConcurrentThreads { get; }
    }
}
