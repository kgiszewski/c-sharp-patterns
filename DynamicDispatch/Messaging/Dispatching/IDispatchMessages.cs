using DynamicDispatch.Messaging.Messages;

namespace DynamicDispatch.Messaging.Dispatching
{
    public interface IDispatchMessages
    {
        object Dispatch(IMessage message);
    }
}
