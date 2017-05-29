using DAL;
using UnitOfWork.Models;
using UnitOfWork.Repositories;

namespace UnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //a unit of work is created
            using (var uow = new PetaPocoUnitOfWork())
            {
                //get an instance of a repo
                var repo = new FooRepository(uow);

                var entity = repo.Get(2);

                //no committing is necessary on a SELECT
            }

            //let's save something
            using (var uow = new PetaPocoUnitOfWork())
            {
                var repo = new FooRepository(uow);

                var entity = repo.Get(0) ?? new MyDbEntity();

                entity.Name = "Minnie Mouse";

                repo.Save(entity);

                //we need to commit our changes or else it won't be saved!
                //if the code throws before this point, the entire transaction is rolled back
                uow.Commit();
            }

            //let's delete something
            using (var uow = new PetaPocoUnitOfWork())
            {
                var repo = new FooRepository(uow);

                var entity = repo.Get(2);

                if (entity != null)
                {
                    repo.Delete(entity);

                    //if we don't make it here or this is never called, the transaction gets rolled back
                    uow.Commit();
                }
            }

            //the best part of a UOW pattern is that you can do many things across more than one repo and have them linked as a single transaction
            using (var uow = new PetaPocoUnitOfWork())
            {
                //look, we need to manipulate TWO repos in the same transaction
                var fooRepo = new FooRepository(uow);
                var barRepo = new BarRepository(uow);

                var entity = fooRepo.Get(0) ?? new MyDbEntity();

                entity.Name = "Minnie Mouse";

                fooRepo.Save(entity);

                var phoneNumber = new MyOtherDbEntity
                {
                    PhoneNumber = "5558675309"
                };

                barRepo.Save(phoneNumber);

                //we need to commit our changes or else it won't be saved!
                //if the code throws before this point, the entire transaction is rolled back
                uow.Commit();
            }
        }
    }
}
