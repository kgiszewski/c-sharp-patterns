namespace Visitor
{
    public interface IVisitFoo
    {
        void Visit(IFoo foo);
        void Visit(Component1 component1);
    }
}
