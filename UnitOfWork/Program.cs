using UnitOfWork.DAL;
using UnitOfWork.Models;
using UnitOfWork.Repositories;

namespace UnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //a unit of work is created
            using (var uow = UnitOfWorkFactory.Get())
            {
                //get an instance of a repo
                var repo = new FooRepository();

                var entity = repo.Get(uow, 2);

                //no committing is necessary on a SELECT
            }

            //let's save something
            using (var uow = UnitOfWorkFactory.Get())
            {
                var repo = new FooRepository();

                var entity = repo.Get(uow, 0) ?? new MyDbEntity();

                entity.Name = "Minnie Mouse";

                repo.Save(uow, entity);

                //we need to commit our changes or else it won't be saved!
                //if the code throws before this point, the entire transaction is rolled back
                uow.Commit();
            }

            //let's delete something
            using (var uow = UnitOfWorkFactory.Get())
            {
                var repo = new FooRepository();

                var entity = repo.Get(uow, 2);

                if (entity != null)
                {
                    repo.Delete(uow, entity);

                    //if we don't make it here or this is never called, the transaction gets rolled back
                    uow.Commit();
                }
            }

            //the best part of a UOW pattern is that you can do many things across more than one repo and have them linked as a single transaction
            using (var uow = UnitOfWorkFactory.Get())
            {
                //look, we need to manipulate TWO repos in the same transaction
                var fooRepo = new FooRepository();
                var barRepo = new BarRepository();

                var entity = fooRepo.Get(uow, 0) ?? new MyDbEntity();

                entity.Name = "Minnie Mouse";

                fooRepo.Save(uow, entity);

                var phoneNumber = new MyOtherDbEntity
                {
                    PhoneNumber = "5558675309"
                };

                barRepo.Save(uow, phoneNumber);

                //we need to commit our changes or else it won't be saved!
                //if the code throws before this point, the entire transaction is rolled back
                uow.Commit();
            }
        }
    }
}
