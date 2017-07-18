namespace CompositionOverInheritance.Composed
{
    public class EnhancedOrder1Composed : IOrder, IOrderEnhanced
    {
        //this class uses composotion and essentially does repeat what Order1 is doing but is now free to evolve independently
        //this could be good or bad but this is the design decision you make by doing compostion vs inheritance
        public int OrderNumber { get; }
        public IAddress ShippingAddress { get; }
        public IAddress BillingAddress { get; }
        public string EnhancedField { get; }
    }
}
