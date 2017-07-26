using System;
using System.Threading;
using Threading.Work;

namespace Threading
{
    class Program
    {
        private static readonly IManageThreads _threadManager = new ThreadManager();
        private static int _mainThreadId;

        static void Main(string[] args)
        {
            var rand = new Random();

            _mainThreadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"Main thread Id: {_mainThreadId}");
            
            //queue up 10 things that need done
            for (var i = 1; i < 10; i++)
            {
                _threadManager.Queue(new DoSomething
                {
                   Id = i,
                   SleepFactor = rand.Next(1, 5) * 1000
                });
            }
            
            //work thru the queue, set max threads
            //the _workerBee method gets run by a new thread
            //the work object will get injected as an arg
            _threadManager.ProcessQueue(_workerBee, 5);

            //since work is outside of this thread, we have to wait for the other threads to finish
            while (_threadManager.NumberThreadsRunning > 0)
            {
                
            }

            Console.WriteLine("All threads complete.");
            Console.WriteLine($"Current number of threads: {_threadManager.NumberThreadsRunning}, Max Threads: {_threadManager.MaxConcurrentThreads}");
            Console.ReadKey();
        }

        //this is the method that does the work
        //many threads will be in this method at the same time, so don't assume you get to do whatever you want without locking
        //work inside the DoSomething class should be thread-safe already
        private static void _workerBee(object o)
        {
            //illustrating that the main thread and this method should always be executing on different threads
            if (_mainThreadId == Thread.CurrentThread.ManagedThreadId)
            {
                throw new Exception("This shouldn't be the case!");
            }

            //the thread manager is using <object>, so we need to cast
            var myDoerClass = o as DoSomething;

            myDoerClass?.Process();

            //this could be done differently if we want the worker method to know nothing about thread management
            //perhaps we could raise an event that the thread manager subscribes to
            //otherwise I don't see an easy way for the thread to be removed from the manager
            _threadManager.RemoveThread();

            Thread.Sleep(5000);
        }
    }
}
