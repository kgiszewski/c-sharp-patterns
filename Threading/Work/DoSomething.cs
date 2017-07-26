using System;
using System.Threading;

namespace Threading.Work
{
    public class DoSomething : IDoSomething
    {
        //just a placeholder class that is unaware that it's in a multithreaded env
        public int Id { get; set; }
        public int SleepFactor { get; set; }
        
        public void Process()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} Processing Object: {Id} Task: {i + 1}/10");

                Thread.Sleep(SleepFactor);
            }

            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} Object {Id} is complete.");
        }
    }
}
