using System.Collections.Generic;
using Komsky.Data.DataAccess.UnitOfWork;

namespace Komsky.Services.Handlers
{
    public abstract class BaseHandler<T> : IBaseHandler<T>
    {
        protected readonly IDataFacade DataFacade;

        public BaseHandler()
        {
            DataFacade = new DataFacade();
        }

        public BaseHandler(IDataFacade dataFacade)
        {
            DataFacade = dataFacade;
        }

        public void Dispose()
        {
            DataFacade.Dispose();
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(int id);

        public abstract void Add(T domainObject);

        public abstract void Update(T domainObject);

        public abstract void Delete(T domainObject);

        public abstract void Delete(int domainObjectId);
    }
}
