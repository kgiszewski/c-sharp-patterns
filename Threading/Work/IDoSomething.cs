namespace Threading.Work
{
    public interface IDoSomething
    {
        string Name { get; set; }
        int SleepFactor { get; set; }
        void Process();
    }
}
