using System;
using Pipeline.PipeModel;

namespace Pipeline.Pipes
{
    //a 'pipe' is just a very focused action, this one represents 'cropping'
    //the real 'crop' code would obviously be different, but the plumbing would remain the same
    public class CropAction : IPipe<ImageModel>
    {
        public ImageModel Process(ImageModel model)
        {
            Console.WriteLine("Cropping!");

            model.ProcessLog += "==>Cropping!";

            return model;
        }
    }
}
