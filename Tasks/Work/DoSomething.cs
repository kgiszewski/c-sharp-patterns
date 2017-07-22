using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks.Work
{
    public class DoSomething
    {
        public void Process1()
        {
            Console.WriteLine("Doing Process1....");

            Thread.Sleep(10000);

            Console.WriteLine("Process1 Done.");
        }

        public string Process2()
        {
            Console.WriteLine("Doing Process2....");

            Thread.Sleep(1000);

            Console.WriteLine("Process2 Done.");

            return "All done.";
        }

        public async Task<string> Process3Async(int sleepInMs = 5000)
        {
            //should run immediately
            Console.WriteLine($"Doing Process3 ({sleepInMs})...");

            //simulates a blocking task
            await Task.Run(() =>
            {
                Thread.Sleep(sleepInMs);
            });

            //this should run afterwards
            Console.WriteLine($"Process3 ({sleepInMs}) Done.");

            return "All done.";
        }
    }
}
