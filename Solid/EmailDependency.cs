using System;

namespace Solid
{
    public class EmailDependency :IEmailDependency
    {
        public void SendMail()
        {
            Console.WriteLine("Sending an email...");
        }
    }
}
