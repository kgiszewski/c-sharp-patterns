using System.Linq;
using UnitOfWork.DAL;
using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    public class BarRepository
    {
        public MyOtherDbEntity Get(IUnitOfWork uow, long id)
        {
            var sql = @"
                SELECT *
                FROM MyOtherDbEntities
                WHERE id = @id
            ";

            return uow.Database.Fetch<MyOtherDbEntity>(sql, new { id = id }).SingleOrDefault();
        }

        public void Save(IUnitOfWork uow, MyOtherDbEntity entity)
        {
            uow.Database.Save(entity);
        }

        public void Delete(IUnitOfWork uow, MyOtherDbEntity entity)
        {
            uow.Database.Delete(entity);
        }
    }
}
