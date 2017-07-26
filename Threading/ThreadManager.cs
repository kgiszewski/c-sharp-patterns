using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Threading
{
    public class ThreadManager : IManageThreads
    {
        //let's keep track of our threads
        private readonly ConcurrentDictionary<int, Thread> _currentRunningThreads = new ConcurrentDictionary<int, Thread>();

        //let's keep track of our work to do
        private readonly Queue<object> _workQueue = new Queue<object>();

        //helper to add a new worker
        public void Queue(object o)
        {
            _workQueue.Enqueue(o);
        }

        //process the queue
        //essentially this is the brains that spawns a new thread
        //this runs on the main thread
        public void ProcessQueue(Action<object> action, int maxThreads)
        {
            //throttle the work
            MaxConcurrentThreads = maxThreads;

            //if anything to do...
            while (_workQueue.Any())
            {
                //using a count on a concurrent dictionary should get us the right count (I hope)
                //limit to the max threads
                if (_currentRunningThreads.Count < MaxConcurrentThreads)
                {
                    Console.WriteLine($"Work queue items: {_workQueue.Count}");

                    //grab some work off the top of the queue
                    var work = _workQueue.Dequeue();

                    //define a new thread
                    var thread = new Thread(new ParameterizedThreadStart(action));

                    //try to add it to the dictionary
                    //maybe we should add some logic here in case the dictionary doesn't let us
                    _currentRunningThreads.TryAdd(thread.ManagedThreadId, thread);

                    Console.WriteLine($"Spawning new thread: {thread.ManagedThreadId}...");
                    Console.WriteLine($"Current number of threads: {_currentRunningThreads.Count}, Max Threads: {MaxConcurrentThreads}");

                    //add some delay so that the console messages slowly crawl
                    Thread.Sleep(5000);

                    //begin the work
                    thread.Start(work);
                }
                else
                {
                    //guess we should wait until we get a thread to use
                    //Console.WriteLine($"Waiting for a thread to come free...");
                    Thread.Sleep(1000);
                }
            }
        }

        public int NumberThreadsRunning => _currentRunningThreads.Count;
        public int MaxConcurrentThreads { get; set; }
        public void RemoveThread()
        {
            Thread t;

            //take the thread out of the mix, this might need better error handling
            _currentRunningThreads.TryRemove(Thread.CurrentThread.ManagedThreadId, out t);

            Console.WriteLine($"Ending thread Id: {t.ManagedThreadId}...");
        }
    }
}
