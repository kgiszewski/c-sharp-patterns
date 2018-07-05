using System.Collections.Generic;

namespace DistributedLocking.Locking
{
    public class InMemoryDistributedLock : IDistributedLock
    {
        private readonly HashSet<string> _locks = new HashSet<string>();
        private readonly object _padLock = new object();

        public bool AcquireLock(string semaphore)
        {
            lock (_padLock)
            {
                if (_locks.Contains(semaphore))
                {
                    return false;
                }

                try
                {
                    _locks.Add(semaphore);
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }

        public void ReleaseLock(string semaphore)
        {
            lock (_padLock)
            {
                if (_locks.Contains(semaphore))
                {
                    _locks.Remove(semaphore);
                }
            }
        }
    }
}
