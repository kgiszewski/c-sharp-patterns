using System;
using System.Threading.Tasks;
using Tasks.Work;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var work = new DoSomething();

            //immediately runs in a separate thread
            var process1Task = Task.Run(() => work.Process1());

            //immediately runs in a separate thread
            var process2Task = Task.FromResult(work.Process2());

            //blocks until it's done due to the 'Result' keyword
            Console.WriteLine($"Status: {process2Task.Result}");

            //let's kick off process3 immediately
            var process3Task = _process3Async(work);

            //and wait for it (meanwhile process 1 is still going likely)
            var process3TaskResult = process3Task.Result;

            Console.WriteLine($"Process3: {process3TaskResult}");

            //if we don't wait, the main thread will exit before Process1 is complete.
            //we'll never risk this with Process2 since we block until it's done
            process1Task.Wait();

            Console.WriteLine("All tasks complete!");

            Console.ReadKey();

            //now let's run three tasks but wait for them all to complete
            //they will end in reverse order
            Task.WaitAll(new Task[]
            {
                work.Process3Async(3000),
                work.Process3Async(2000),
                work.Process3Async(1000)
            });

            Console.WriteLine("All tasks complete!");

            Console.ReadKey();

            //now let's run three tasks but wait for ONLY ONE of them to complete
            //they will end in reverse order
            Task.WaitAny(new Task[]
            {
                work.Process3Async(3000),
                work.Process3Async(2000),
                work.Process3Async(1000)
            });

            Console.WriteLine("One task complete!");
           
            Console.ReadKey();
        }

        //you can define an async task by using the 'async' keyword, the 'Task<TResult>` return type and the 'await keyword on something
        //defined as a task
        private static async Task<string> _process3Async(DoSomething work)
        {
            return await work.Process3Async();
        }
    }
}
