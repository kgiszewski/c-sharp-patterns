using System;
using DynamicDispatch.Messaging.Dispatching;
using DynamicDispatch.Messaging.Messages;

namespace DynamicDispatch
{
    class Program
    {
        static void Main(string[] args)
        {
            //this class will 'route' our message to a handler
            IDispatchMessages messageDispatcher = new MessageDispatcher();

            //send a FooMessage and get a response from IHandleMessages<FooMessage>
            //I'm using a convention here, of the message class and the handler class should be named like so:
            /*
             * <name>Message and <name>Handler
             * 
             * So in the case of a message/handler pair named Foo, you'd create a FooMessage class and a FooHandler class 
             */

            //the messages are unique and don't need anything other than a marker interface called IMessage
            var response = messageDispatcher.Dispatch(new FooMessage
            {
                FooId = 1234,
                Name = "Mr. Foo"
            });
            
            Console.WriteLine(response);

            //this message class is completely different
            response = messageDispatcher.Dispatch(new BarMessage()
            {
                Age = 99
            });

            Console.WriteLine(response);

            //once the dispatcher is created, to add new functionality is a matter of adding a new message\handler pair

            Console.ReadKey();
        }
    }
}
