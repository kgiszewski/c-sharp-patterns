using System.Linq;
using DAL;
using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    public class BarRepository
    {
        private readonly PetaPocoUnitOfWork _unitOfWork;

        public BarRepository(PetaPocoUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MyOtherDbEntity Get(long id)
        {
            var sql = @"
                SELECT *
                FROM MyOtherDbEntities
                WHERE id = @id
            ";

            return _unitOfWork.Database.Fetch<MyOtherDbEntity>(sql, new { id = id }).SingleOrDefault();
        }

        public void Save(MyOtherDbEntity entity)
        {
            _unitOfWork.Database.Save(entity);
        }

        public void Delete(MyOtherDbEntity entity)
        {
            _unitOfWork.Database.Delete(entity);
        }
    }
}
