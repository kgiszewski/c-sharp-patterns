using System;
using Pipeline.PipeModel;

namespace Pipeline.Pipes
{
    public class DesaturateAction : IPipe<ImageModel>
    {
        public ImageModel Process(ImageModel model)
        {
            Console.WriteLine("Desaturating!");

            model.ProcessLog += "==>Desaturating!";

            return model;
        }
    }
}
