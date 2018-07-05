namespace DistributedLocking.Locking
{
    public interface IDistributedLock
    {
        bool AcquireLock(string semaphore);
        void ReleaseLock(string semaphore);
    }
}
