namespace Visitor
{
    public interface IVisitable
    {
        void HandleVisitor(IVisitFoo visitor);
    }
}
