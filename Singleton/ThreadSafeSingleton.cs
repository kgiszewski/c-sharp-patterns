using System;

namespace Singleton
{
    public class ThreadSafeSingleton
    {
        //this will hold the internal instance of our singleton
        private static volatile ThreadSafeSingleton _instance;

        //this is used purely for thread safety
        private static readonly object _padLock = new object();

        //you can create as many properties as you'd like
        public string PropertyOne;
        
        //note that the constructor is private and only the class itself can create a new instance
        private ThreadSafeSingleton()
        {
        }

        //this is where the instance will live, notice the return value is the singleton class itself
        public static ThreadSafeSingleton Instance
        {
            get
            {
                //using double check locking to make this thread-safe
                //if already initialized, it'll just return the already created instance
                if (_instance == null)
                {
                    lock (_padLock)
                    {
                        if (_instance == null)
                        {
                            //this will only run if the singleton has never been initialized or has been set to null
                            //otherwise this code will never run after the first time
                            Console.WriteLine("Initializing singleton...");

                            //create an instance and set it to your private member
                            _instance = new ThreadSafeSingleton();

                            //set the values of any properties you have
                            _instance.PropertyOne = "Hello World!";
                        }
                    }
                }

                return _instance;
            }
        }

        //a helper method designed to set the singleton to null which triggers a rebuilding of the instance on next use
        public void Clear()
        {
            Console.WriteLine("Clearing singleton...");

            //by setting this to null, the next thread that uses this singleton will cause it to reinitialize
            _instance = null;
        }
    }
}
