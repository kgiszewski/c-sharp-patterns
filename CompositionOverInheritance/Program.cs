using System;
using CompositionOverInheritance.Composed;
using CompositionOverInheritance.Inherited;

namespace CompositionOverInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * You've heard it before 'favor composition over inheritance.
             * I take that to mean tha when you inherit, you are making a lot of assumptions about the future. When the 'base' class evolves, so will
             * everything 'downstream' on the inheritance chain. This could be desirable or it could create a bunch of un-used properties when dealing
             * with edge cases.
             * 
             * I tend to prefer composition. Meaning that rather than inherit, I just implement an inteface multiple times to better tailor the modeling.
             * In this way you can evolve each piece separately and not have to deal with the baggage of inheritance.
             */

            //the base class
            var order1 = new Order1();

            //inheritance
            var order1EnhancedInherited = new EnhancedOrder1Inherited();

            //composition
            var order1EnhancedComposed = new EnhancedOrder1Composed();

            //another way to compose is to wrap the original that I tend to prefer
            var order1EnhancedComposedAlternate = new EnhancedOrder1ComposedAlternate
            {
                Order = new Order1()
            };
            

            //only to show each one being used
            var processor = new OrderProcessor();

            //base
            processor.Process(order1);
            
            //inherited
            processor.Process((IOrder)order1EnhancedInherited);
            processor.Process((IOrderEnhanced)order1EnhancedInherited);
            
            //composed
            processor.Process((IOrder)order1EnhancedComposed);
            processor.Process((IOrderEnhanced)order1EnhancedComposed);

            //composed alternate
            processor.Process(order1EnhancedComposedAlternate.Order);
            processor.Process(order1EnhancedComposedAlternate);

            Console.ReadKey();
        }
    }
}
