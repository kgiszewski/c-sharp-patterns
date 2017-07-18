namespace CompositionOverInheritance.Inherited
{
    public class EnhancedOrder1Inherited : Order1, IOrderEnhanced
    {
        //this class will be tied to any changes that happens in Order1 which could be good or bad
        //but this is the design\decision pattern you make when you use inheritance
        public string EnhancedField { get; }
    }
}
