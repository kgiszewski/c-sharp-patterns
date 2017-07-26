namespace Threading.Work
{
    public interface IDoSomething
    {
        int Id { get; set; }
        int SleepFactor { get; set; }
        void Process();
    }
}
