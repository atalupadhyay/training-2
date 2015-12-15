using System;
using System.Collections.Generic;

namespace Komsky.Services.Handlers
{
public interface IBaseHandler<T> : IDisposable
{
    IEnumerable<T> GetAll();
    T GetById(Int32 id);
    void Add(T domainObject);
    void Update(T domainObject);
    void Delete(T domainObject);
    void Delete(int domainObjectId);

}
}
