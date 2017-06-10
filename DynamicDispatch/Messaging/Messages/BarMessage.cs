namespace DynamicDispatch.Messaging.Messages
{
    //simple POCO with a marker interface
    public class BarMessage : IMessage
    { 
        public int Age { get; set; }
    }
}
