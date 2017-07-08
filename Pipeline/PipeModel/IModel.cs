namespace Pipeline.PipeModel
{
    //a simple model that must be used in the pipeline
    //adjust this to suit your needs
    public interface IModel
    {
        string ProcessLog { get; set; }
    }
}
