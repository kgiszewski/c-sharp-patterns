using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Threading.Work;

namespace Threading
{
    public class ThreadManager : IManageThreads
    {
        private readonly List<int> _currentRunningThreads = new List<int>();
        private readonly Queue<object> _workQueue = new Queue<object>();

        public void Queue(object o)
        {
            _workQueue.Enqueue(o);
        }

        public void ProcessQueue()
        {
            while (_workQueue.Any())
            {
                Console.WriteLine($"Work queue items: {_workQueue.Count}");

                if (_currentRunningThreads.Count < MaxConcurrentThreads)
                {
                    var work = _workQueue.Dequeue();
                    var thread = new Thread(WorkerBee);

                    _currentRunningThreads.Add(thread.ManagedThreadId);

                    thread.Start(work);
                }
                else
                {
                    Console.WriteLine($"Waiting for a thread to come free...");
                    Thread.Sleep(1000);
                }
            }
        }

        public int NumberThreadsRunning => _currentRunningThreads.Count;
        public int MaxConcurrentThreads => 2;
        private void WorkerBee(object o)
        {
            var myDoerClass = o as DoSomething;

            myDoerClass?.Process();

            _currentRunningThreads.Remove(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
