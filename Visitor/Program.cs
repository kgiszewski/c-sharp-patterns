namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //if we have class Foo which implements IFoo, we may want to add functionality to it without modifying Foo
            //the gist of this pattern is that we'll make available the components so that another class can do some custom logic
            //to do so we can use double dispatch to essentially provide a callback to another class with Foo as an arg
            //this pattern is known as the Visitor pattern
            IFoo foo = new Foo();

            //class Bar will add extra functionality to Foo and it can even allow for private vars to be available to Bar
            IVisitFoo bar = new Bar();

            //Foo makes itself and optionally private args to Bar
            //Bar can optionally only use certain items inside Foo or use all of them and Foo controls what it makes available to Bar
            foo.HandleVisitor(bar);

            //the visitor pattern allows for swappable behavior by simply changing the visitor
            //it can also be used to handle a pipeline of steps that must be performed

            foo.HandleVisitor(new AnotherBar());

            //this pattern can be super useful if the author of Foo didn't want to share their code nor wanted to allow anyone to modify it
            //the visitor pattern can let another author do custom work without having to worry about leaking business logic into a core class
        }
    }
}
