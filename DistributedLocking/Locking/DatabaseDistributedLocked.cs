namespace DistributedLocking.Locking
{
    public class DatabaseDistributedLock : IDistributedLock
    {
        /*
         * This assumes you have a column to hold the semaphore and it is unique
         *
         * Any attempt to insert a semaphore already in the db will fail
         *
         * Actual db imple left out as it's trivial and based on whatever you want it to be
         *
         */

        public bool AcquireLock(string semaphore)
        {
            var alreadyInDb = false; //get from DB
            
            if (alreadyInDb)
            {
                return false;
            }

            try
            {
                //insert into db
                var wasInserted = true;

                if (wasInserted)
                {
                    //success
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public void ReleaseLock(string semaphore)
        {
            //delete from db
        }
    }
}
