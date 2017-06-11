namespace Solid
{
    public class SolidUserRecordUpdater : ISolidUserRecordUpdater
    {
        private readonly IUpdateUserRecords _updater;
        private readonly IEmailDependency _emailDependency;

        public SolidUserRecordUpdater(IUpdateUserRecords updater, IEmailDependency emailDependency)
        {
            _updater = updater;
            _emailDependency = emailDependency;
        }

        public void DoSomethingElse()
        {
            _updater.DoSomeUpdates();
        }

        public void DoSomethingElseAgain()
        {
            _updater.DoSomeUpdates();
            _emailDependency.SendMail();
        }
    }
}
