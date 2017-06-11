namespace Solid
{
    public class SolidEmailer :ISolidEmailer
    {
        private readonly IEmailDependency _emailDependency;

        //we take our dependencies via the constructor and they are of an abstracted type
        //swapping which emailer we use is simple
        public SolidEmailer(IEmailDependency emailDependency)
        {
            _emailDependency = emailDependency;
        }

        //we limit this class to only handle emailing
        public void SendMail()
        {
            _emailDependency.SendMail();
        }
    }
}
