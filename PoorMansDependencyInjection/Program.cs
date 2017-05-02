namespace PoorMansDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Poor man's DI is just a way to keep your code SOLID without the use of a DI container
             */

            //for instance a typical developer might write a class like Foo where it's dependencies are trapped in the body of a method
            var foo = new Foo();
            foo.Blah();

            //in general, that may be good enough but if you inspect class Foo, you'll see that it needs class Bar. At test time
            //you'll have a difficult time mocking or switching off that code without doing some pretty strange configuration setups

            //meet class BetterFoo, it takes a dependency via the constructor
            var betterFoo = new BetterFoo(new Bar());
            betterFoo.Blah();

            //meet yet another twist on it by meeting class BetterFoo2. This class has a default use of IBar and doesn't need to be passed
            //explicitly AND it can be swapped out
            var betterFoo2 = new BetterFoo2();
            betterFoo2.Blah();

            //as-is, betterFoo2 will use Bar as the IBar impl, however if I want to use Bar2 instead, I can do the following
            betterFoo2.Bar = new Bar2();
            betterFoo2.Blah();

            //as my buddy @bleedo (on Twitter) pointed out, you can have yet another way to have a better foo. BestFoo has a default constructor
            //with the ability to pass dependencies via an overloaded constructor
            var bestFoo = new BestFoo();
            bestFoo.Blah();

            bestFoo = new BestFoo(new Bar2());
            bestFoo.Blah();
        }
    }
}
