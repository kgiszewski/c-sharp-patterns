using System;
using DynamicDispatch.Messaging.Helpers;
using DynamicDispatch.Messaging.Messages;

namespace DynamicDispatch.Messaging.Dispatching
{
    public class MessageDispatcher : IDispatchMessages
    {
        //this class uses a helper for conciseness, but based on the IMessage class name, we can instantiate a handler
        //and send the message to it
        public object Dispatch(IMessage message)
        {
            //in the case of 'FooMessage' this will return 'Foo'
            var nameOfMessageClass = message.GetType().Name.ToMessageName();

            //this goes and gets the handler type based on the name of the message class
            var handlerType = MessageHelper.GetMessageHandlerByMessageTypeName(nameOfMessageClass);

            //this creates an instance at runtime
            var handlerInstance = Activator.CreateInstance(handlerType);

            //finally we execute the new handler instance
            //i'm not a fan of the 'dynamic' keyword but it works well here
            return ((dynamic) handlerInstance).Handle((dynamic)message);
        }
    }
}
