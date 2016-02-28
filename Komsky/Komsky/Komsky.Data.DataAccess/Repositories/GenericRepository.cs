using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Komsky.Data.DataAccess.Repositories
{

public class GenericRepository<T> : IDisposable, IRepository<T> where T : class
{
    public GenericRepository(DbContext dbContext)
    {
        if (dbContext == null)
        {
            throw new ArgumentNullException("dbContext");
        }

        DbContext = dbContext;
        DbSet = DbContext.Set<T>();
    }

    protected DbContext DbContext { get; set; }

    protected DbSet<T> DbSet { get; set; }

    public virtual IQueryable<T> GetAll()
    {
        return DbSet;
    }
    /// <summary>
    /// This generic method has been added outside the scope of the course,
    ///  but is here for completnesness of the reposiotory example.
    /// </summary>
    /// <param name="filter">Filtering expression</param>
    /// <param name="orderBy">Order by expression</param>
    /// <param name="includeProperties">List of included properties</param>
    /// <returns>Queried data</returns>
    public virtual IEnumerable<T> Get(
    Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    string includeProperties = "")
    {
        IQueryable<T> query = DbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        if (orderBy != null)
        {
            return orderBy(query);
        }
        else
        {
            return query;
        }
    }

    public virtual T GetById(int id)
    {
        return DbSet.Find(id);
    }

    public virtual T GetById(Guid id)
    {
        return DbSet.Find(id);
    }

    public virtual T GetById(string id)
    {
        return DbSet.Find(id);
    }

    public virtual void Add(T entity)
    {
        DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

        if (dbEntityEntry.State != EntityState.Detached)
        {
            dbEntityEntry.State = EntityState.Added;
        }
        else
        {
            DbSet.Add(entity);
        }
    }

    public virtual void Update(T entity)
    {
        DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

        if (dbEntityEntry.State == EntityState.Detached)
        {
            DbSet.Attach(entity);
        }

        dbEntityEntry.State = EntityState.Modified;
    }

    public virtual void Delete(T entity)
    {
        DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

        if (dbEntityEntry.State != EntityState.Deleted)
        {
            dbEntityEntry.State = EntityState.Deleted;
        }
        else
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }
    }

    public virtual void Delete(int id)
    {
        var entity = GetById(id);

        if (entity == null)
        {
            return;
        }

        Delete(entity);
    }

    public virtual void Delete(Guid id)
    {
        var entity = GetById(id);

        if (entity == null)
        {
            return;
        }

        Delete(entity);
    }

    public virtual void Delete(string id)
    {
        var entity = GetById(id);

        if (entity == null)
        {
            return;
        }

        Delete(entity);
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }
}
}
