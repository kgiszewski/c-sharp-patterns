using System;

namespace Singleton
{
    public class MySingleton
    {
        private static volatile MySingleton _instance;
        private static object _padLock = new Object();

        //you can create as many properties as you'd like
        public string PropertyOne;
        
        //note that the constructor is private and only the class itself can create a new instance
        private MySingleton()
        {
        }

        //this is where the instance will live, notice the return value is the singleton class itself
        public static MySingleton Instance
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
                            Console.WriteLine("Initializing singleton...");

                            _instance = new MySingleton();

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
            _instance = null;
        }
    }
}
