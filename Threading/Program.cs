using System;
using System.Threading;
using Threading.Work;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main thread Id: {Thread.CurrentThread.ManagedThreadId}");

            var mySomethingDoer = new DoSomething
            {
                Name = "Thing 1",
                SleepFactor = 100
            };

            var mySomethingDoer2 = new DoSomething
            {
                Name = "Thing 2",
                SleepFactor = 1000
            };

            var mySomethingDoer3 = new DoSomething
            {
                Name = "Thing 3",
                SleepFactor = 1000
            };

            var mySomethingDoer4 = new DoSomething
            {
                Name = "Thing 4",
                SleepFactor = 100
            };

            var threadManager = new ThreadManager();

            threadManager.Queue(mySomethingDoer);
            threadManager.Queue(mySomethingDoer2);
            threadManager.Queue(mySomethingDoer3);
            threadManager.Queue(mySomethingDoer4);

            threadManager.ProcessQueue();

            while (threadManager.NumberThreadsRunning > 0)
            {
                
            }

            Console.WriteLine("All threads complete.");
            Console.ReadKey();
        }
    }
}
