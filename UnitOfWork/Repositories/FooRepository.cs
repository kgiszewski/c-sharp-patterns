using System.Linq;
using UnitOfWork.DAL;
using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    //nothing crazy here, note that each CRUD operation needs a UOW to operate on
    //the UOW is not managed by the repo but could possibly be passed in at the class level
    //instead of each method
    public class FooRepository
    {
        public MyDbEntity Get(IUnitOfWork uow, long id)
        {
            var sql = @"
                SELECT *
                FROM MyDbEntities
                WHERE id = @id
            ";

            return uow.Database.Fetch<MyDbEntity>(sql, new { id = id}).SingleOrDefault();
        }

        public void Save(IUnitOfWork uow, MyDbEntity entity)
        {
            uow.Database.Save(entity);
        }

        public void Delete(IUnitOfWork uow, MyDbEntity entity)
        {
            uow.Database.Delete(entity);
        }
    }
}
