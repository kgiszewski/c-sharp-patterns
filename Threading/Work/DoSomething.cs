using System;
using System.Threading;

namespace Threading.Work
{
    public class DoSomething : IDoSomething
    {
        private readonly Random _rand = new Random();
        public string Name { get; set; }
        public int SleepFactor { get; set; }
        
        public void Process()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} Processing: {Name} - {i + 1}");

                Thread.Sleep(_rand.Next(1, 5) * SleepFactor);
            }

            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} {Name} is complete.");
        }
    }
}
