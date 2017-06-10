using DynamicDispatch.Messaging.Messages;

namespace DynamicDispatch.Messaging.Handlers
{
    public class BarHandler : IHandleMessages<BarMessage>
    {
        //fully typed for the message type
        public object Handle(BarMessage message)
        {
            return $"Hello from the Bar handler: {message.Age}";
        }
    }
}
