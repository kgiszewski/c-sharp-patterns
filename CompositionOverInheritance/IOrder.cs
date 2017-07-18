using System.Net;

namespace CompositionOverInheritance
{
    public interface IOrder
    {
        int OrderNumber { get; }
        IAddress ShippingAddress { get; }
        IAddress BillingAddress { get; }
    }
}
