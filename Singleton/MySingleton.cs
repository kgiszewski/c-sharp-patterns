using System;

namespace Singleton
{
    public class MySingleton
    {
        private static volatile MySingleton _instance;
        private static object _padLock = new Object();

        public string PropertyOne;

        private MySingleton()
        {
        }

        public static MySingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padLock)
                    {
                        if (_instance == null)
                        {
                            Console.WriteLine("Initializing singleton...");

                            _instance = new MySingleton();

                            _instance.PropertyOne = "Hello World!";
                        }
                    }
                }

                return _instance;
            }
        }

        public void Clear()
        {
            Console.WriteLine("Clearing singleton...");
            _instance = null;
        }
    }
}
