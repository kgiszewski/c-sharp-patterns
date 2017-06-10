namespace DynamicDispatch.Messaging.Messages
{
    //simple POCO with a marker interface
    public class FooMessage : IMessage
    {
        public int FooId { get; set; }
        public string Name { get; set; }
    }
}
