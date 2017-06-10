using DynamicDispatch.Messaging.Messages;

namespace DynamicDispatch.Messaging.Handlers
{
    public class FooHandler : IHandleMessages<FooMessage>
    {
        //fully typed for the message type
        public object Handle(FooMessage message)
        {
            return $"Hello from the Foo Handler! Foo Id: {message.FooId} {message.Name}";
        }
    }
}
