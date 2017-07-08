using System;
using Pipeline.PipeModel;

namespace Pipeline.Pipes
{
    public class RotateAction : IPipe<ImageModel>
    {
        public ImageModel Process(ImageModel model)
        {
            Console.WriteLine("Rotating!");

            model.ProcessLog += "==>Rotating!";

            return model;
        }
    }
}
