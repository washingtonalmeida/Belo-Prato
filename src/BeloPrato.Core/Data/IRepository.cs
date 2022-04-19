using BeloPrato.Core.DomainObjects;
using System;

namespace BeloPrato.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
