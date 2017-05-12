using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApplication.Repository.Interfaces
{
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> GetAll();
		TEntity Find(object Id);
		IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
		void Add(TEntity entity);
		void Delete(TEntity entity);
		void Edit(TEntity entity);
		void Save();

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        void Dispose(bool disposing);
        /// <summary>
        /// Disposes this instance.
        /// </summary>
        void Dispose();
    }
}
