using System;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            //SOLID programming is a way to keep your code maintainable
            /*
             * It is an acronym and the Wikipedia definition can be found here: https://en.wikipedia.org/wiki/SOLID_(object-oriented_design)
             * 
             * S - Single Responsibility. This one is the most subjective of the definitions. However you should favor smaller classes
             * that do specific things as opposed to large classes that do too much.
             * O - Open\Closed Principle. Classes should be 'open' for extension and 'closed' for modification. Again more subjectivity
             * but if a class doesn't need to be altered and offers extension points; it adheres better to this principle than a class
             * that needs to be updated often.
             * L - Liskov Substitution Principle. This is more about polymorphism and abstraction. You should be using interfaces and\or
             * abstract classes when depending on another class. Therefore when you want to change out a dependency, the contract (interface)
             * allows you to.
             * I - Interface Segregation Principle - This sort of blends the 'O' and the 'I' with a little bit of 'S'. Favor smaller specific
             * purpose interfaces to large interfaces that do too much. There is no example here, but just think of a giant abstraction that does 
             * too much.
             * D - Dependency Inversion Principle - Depend on abstractions, not concrete classes. More blending of the above, but dependencies
             * should be pass thru a constructor or property as an abstraction and not a concrete class. Also do not 'trap' a dependency.
             *
             *
             * ** Remember, these are guidelines, not hard-fast rules. Feel free to make exceptions as needed. **
             */
             
            var notSolid = new NotSolid();

            notSolid.DoSomething();
            notSolid.DoSomethingElse();

            //we take our dependencies via the constructor, view the definition to notice we are depending on an interface and not a concrete mailer
            var solidEmailer = new SolidEmailer(new EmailDependency());
            solidEmailer.SendMail();

            //same as above, but we split the user record updates from the emails
            //we take the email dependency as a dependency
            var solidUpdater = new SolidUserRecordUpdater(new UpdateUserRecords(), new EmailDependency());
            solidUpdater.DoSomethingElse();
            solidUpdater.DoSomethingElseAgain();

            Console.ReadKey();
        }
    }
}
