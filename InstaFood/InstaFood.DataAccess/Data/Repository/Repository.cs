/*
    Description: Repository class implementation
    
    Author: WarOfDevil          Date: 27-02-2020
*/


using InstaFood.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InstaFood.DataAccess.Data.Repository
{
    /// <summary>
    /// Repository pattern implementation.
    /// Contains all methods definition to Add, Get and Remove objects
    /// from a database context.
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// Database table of a specific entity
        /// </summary>
        internal DbSet<T> dbSet;

        /// <summary>
        /// Costructor, set database context and create a new dataset.
        /// </summary>
        /// <param name="context">The database context</param>
        public Repository(DbContext context)
        {
            Context = context;
            dbSet = context.Set<T>();
        }

        /// <summary>
        /// Insert an object to the database context
        /// </summary>
        /// <param name="entity">A generic object</param>
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Select an object based on its primary key
        /// </summary>
        /// <returns>
        /// Return a generic object
        /// </returns>
        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Select all objects
        /// </summary>
        /// <param name="filter">Specify a filter</param>
        /// <param name="orderBy">Specify items collection order</param>
        /// <param name="includeProperties">Specify property</param>
        /// <returns>
        /// Return a collection of objects
        /// </returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Include properties will be coma separated
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        /// <summary>
        /// Get the first found object or return default value
        /// </summary>
        /// <param name="filter">Specify a filter</param>
        /// <param name="includeProperties">Specify property</param>
        /// <returns>
        /// Return an object or default value
        /// </returns>
        public T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null, 
            string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Include properties will be coma separated
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Remove an object from the database context based on the primary key
        /// </summary>
        /// <param name="id">Object primary key</param>
        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
            Remove(entityToRemove);
        }

        /// <summary>
        /// Remove the object from the database context
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
