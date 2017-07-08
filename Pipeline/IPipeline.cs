using Pipeline.PipeModel;
using Pipeline.Pipes;

namespace Pipeline
{
    //an interface that represents the required methods of a pipeline
    //the TModel and where are generic and require the model used to be of type IModel
    public interface IPipeline<TModel> where TModel : IModel
    {
        void Register(IPipe<TModel> pipe);
        void RemoveAt(int index);
        void Process(TModel model);
    }
}
