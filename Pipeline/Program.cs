using System;
using Pipeline.PipeModel;
using Pipeline.Pipes;

namespace Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a new pipeline
            var pipeLine = new ImagePipeline();
            //create a simple object to represent an image
            //the real image manipulation details would be much more involved
            var image = new ImageModel();

            //add the actions that the pipeline should do in a particular order
            pipeLine.Register(new CropAction());
            pipeLine.Register(new DesaturateAction());
            pipeLine.Register(new RotateAction());

            //process the image based on the the above
            pipeLine.Process(image);

            //let's see what steps actually were taken
            Console.WriteLine(image.ProcessLog);
            
            //let's remove the desaturate action
            pipeLine.RemoveAt(1);
            //we'll add a rotation
            pipeLine.Register(new RotateAction());
            //let's reprocess the image
            pipeLine.Process(image);

            //let's see what steps ran
            Console.WriteLine(image.ProcessLog);

            Console.ReadKey();
        }
    }
}
