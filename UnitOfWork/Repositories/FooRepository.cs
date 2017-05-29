using System;
using System.Linq;
using DAL;
using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    //nothing crazy here, note that each CRUD operation needs a UOW to operate on
    //the UOW is not managed by the repo but could possibly be passed in at the class level
    //instead of each method
    public class FooRepository
    {
        private readonly PetaPocoUnitOfWork _unitOfWork;

        public FooRepository(PetaPocoUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MyDbEntity Get(long id)
        {
            var sql = @"
                SELECT *
                FROM MyDbEntities
                WHERE id = @id
            ";

            return _unitOfWork.Database.Fetch<MyDbEntity>(sql, new { id = id}).SingleOrDefault();
        }

        public void Save(MyDbEntity entity)
        {
            _unitOfWork.Database.Save(entity);
        }

        public void Delete(MyDbEntity entity)
        {
            _unitOfWork.Database.Delete(entity);
        }
    }
}
