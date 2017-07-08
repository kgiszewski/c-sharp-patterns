using System.Collections.Generic;
using Pipeline.PipeModel;
using Pipeline.Pipes;

namespace Pipeline
{
    //implementation of a pipeline
    public class ImagePipeline : IPipeline<ImageModel>
    {
        //we'll store the registered actions here
        private readonly List<IPipe<ImageModel>> _pipeline = new List<IPipe<ImageModel>>();

        public void Register(IPipe<ImageModel> pipe)
        {
            _pipeline.Add(pipe);
        }

        public void RemoveAt(int index)
        {
            _pipeline.RemoveAt(index);
        }

        //just a simple loop that calls process on each pipe segment
        public void Process(ImageModel model)
        {
            foreach (var pipe in _pipeline)
            {
                pipe.Process(model);
            }
        }
    }
}
