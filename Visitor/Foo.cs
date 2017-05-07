namespace Visitor
{
    public class Foo : IFoo
    {
        //this is a private var which we can expose it's object to a visitor (below)
        private Component1 _component1 => new Component1();

        private Component2 _component2;
        public Component2 Component2 => _component2 ?? (_component2 = new Component2());

        private Component3 _component3;
        public Component3 Component3 => _component3 ?? (_component3 = new Component3());

        public void HandleVisitor(IVisitFoo visitor)
        {
            //this will allow for _component1 to be visible to the visitor
            _component1.HandleVisitor(visitor);

            //this will give a reference of all of the public members to the visitor
            visitor.Visit(this);
        }
    }
}
