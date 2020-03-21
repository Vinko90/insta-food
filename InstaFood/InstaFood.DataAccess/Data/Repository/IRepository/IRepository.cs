/*
    Description: IRepository interface
    
    Author: WarOfDevil          Date: 27-02-2020
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Repository pattern interface.
    /// Contains all methods definition to Add, Get and Remove objects
    /// from a database context.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Select an object based on its primary key
        /// </summary>
        /// <returns>
        /// Return a generic object
        /// </returns>
        T Get(int id);

        /// <summary>
        /// Select all objects
        /// </summary>
        /// <param name="filter">Specify a filter</param>
        /// <param name="orderBy">Specify items collection order</param>
        /// <param name="includeProperties">Specify property</param>
        /// <returns>
        /// Return a collection of objects
        /// </returns>
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        /// <summary>
        /// Get the first found object or return default value
        /// </summary>
        /// <param name="filter">Specify a filter</param>
        /// <param name="includeProperties">Specify property</param>
        /// <returns>
        /// Return an object or default value
        /// </returns>
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        /// <summary>
        /// Insert an object to the database context
        /// </summary>
        /// <param name="entity">A generic object</param>
        void Add(T entity);

        /// <summary>
        /// Remove an object from the database context based on the primary key
        /// </summary>
        /// <param name="id">Object primary key</param>
        void Remove(int id);

        /// <summary>
        /// Remove the object from the database context
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        void Remove(T entity);

        /// <summary>
        /// Remove a collection of objects from the database context
        /// </summary>
        /// <param name="entity">The list of entity to be removed</param>
        void RemoveRange(IEnumerable<T> entity);
    }
}
