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
    /// Contains all methods definition to Add, Get and Remove items
    /// from a database context.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get an item based on its primary key
        /// </summary>
        /// <returns>
        /// Return a generic item
        /// </returns>
        T Get(int id);

        /// <summary>
        /// Get all the items
        /// </summary>
        /// <param name="filter">Specify a filter</param>
        /// <param name="orderBy">Specify items collection order</param>
        /// <param name="includeProperties">Specify property</param>
        /// <returns>
        /// Return a collection of items
        /// </returns>
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        /// <summary>
        /// Get the first found item or return default
        /// </summary>
        /// <param name="filter">Specify a filter</param>
        /// <param name="includeProperties">Specify property</param>
        /// <returns>
        /// Return an item or default
        /// </returns>
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        /// <summary>
        /// Add an item to the database context
        /// </summary>
        /// <param name="entity">A generic item</param>
        void Add(T entity);

        /// <summary>
        /// Remove an item from the database context based on the primary key
        /// </summary>
        /// <param name="id">Item primary key</param>
        void Remove(int id);

        /// <summary>
        /// Remove the item from the database context
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        void Remove(T entity);
    }
}
