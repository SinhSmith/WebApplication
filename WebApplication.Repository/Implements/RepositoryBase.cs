using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebApplication.Model.Context;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Implements
{
	public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
	{
		protected OnlineStoreMVCEntities context;
		protected readonly DbSet<TEntity> dbSet;

		public RepositoryBase(OnlineStoreMVCEntities context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return dbSet.AsEnumerable<TEntity>();
		}

		public virtual TEntity Find(object Id)
		{
			return dbSet.Find(Id);
		}

		public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
		{
			IEnumerable<TEntity> query = dbSet.Where(predicate).AsEnumerable();
			return query;
		}

		public virtual void Add(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			dbSet.Remove(entity);
		}

		public virtual void Edit(TEntity entity)
		{
			context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Save()
		{
			context.SaveChanges();
		}

        #region Dispose context
        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
