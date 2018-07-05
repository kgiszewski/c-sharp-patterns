using System;
using System.Threading;
using System.Threading.Tasks;
using DistributedLocking.Locking;

namespace DistributedLocking
{
    class Program
    {
        private static readonly IDistributedLock _locker = new InMemoryDistributedLock();
        private static string mySemaphore = "1234customerPayment";
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                Task.Run(() => _doWork(mySemaphore));

                Thread.Sleep(_random.Next(100, 500));
            }
        }

        private static void _doWork(string semaphore)
        {
            var isThreadLocked = _locker.AcquireLock(semaphore);

            Console.WriteLine($"Did we get a lock => {isThreadLocked}");

            if (isThreadLocked)
            {
                Console.WriteLine("Working...");

                Thread.Sleep(_random.Next(1000, 3000));

                _locker.ReleaseLock(semaphore);
            }
        }
    }
}
