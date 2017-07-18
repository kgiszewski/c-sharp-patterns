using System;

namespace CompositionOverInheritance
{
    public class OrderProcessor
    {
        public void Process(IOrder order)
        {
            Console.WriteLine("Processing an IOrder...");
        }

        public void Process(IOrderEnhanced order)
        {
            Console.WriteLine("Processing an IEnhancedOrder...");
        }
    }
}
