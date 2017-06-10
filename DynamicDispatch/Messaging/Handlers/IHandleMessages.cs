using DynamicDispatch.Messaging.Messages;

namespace DynamicDispatch.Messaging.Handlers
{
    public interface IHandleMessages<in TMessage> where TMessage : IMessage
    {
        object Handle(TMessage message);
    }
}
