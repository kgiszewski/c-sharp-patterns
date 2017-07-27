using System;
using PetaPoco;

namespace UnitOfWork.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IDatabase Database { get; }
    }
}
