namespace Singleton
{
    public class NonThreadSafeSingleton
    {
        //holds our one and only instance
        private static NonThreadSafeSingleton _nonThreadSafeSingleton;

        //private constructor to disallow anyone 'new'ing one up
        private NonThreadSafeSingleton()
        {
            
        }

        //add as many properties as you want
        public string PropertyOne { get; set; }

        //the 'instance' property initializes our private instance or returns if already initialized
        public static NonThreadSafeSingleton Instance => _nonThreadSafeSingleton ?? (_nonThreadSafeSingleton = new NonThreadSafeSingleton());
    }
}
