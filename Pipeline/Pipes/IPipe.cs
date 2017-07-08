using Pipeline.PipeModel;

namespace Pipeline.Pipes
{
    //an interface that represents a 'pipe' action
    //i've constrained the TModel to be of type IModel
    public interface IPipe<TModel> where TModel : IModel
    {
        //what comes in will be altered and then returned as output
        TModel Process(TModel input);
    }
}
