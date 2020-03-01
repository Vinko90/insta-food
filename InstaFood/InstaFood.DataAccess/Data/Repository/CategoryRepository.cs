/*
    Description: CategoryRepository class implementation
    
    Author: WarOfDevil          Date: 27-02-2020
*/


using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace InstaFood.DataAccess.Data.Repository
{
    /// <summary>
    /// Category Repository pattern class.
    /// </summary>
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Costructor
        /// Initialize database context and send reference to Repository base class
        /// </summary>
        /// <param name="db">Database context</param>
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Select all category items from database
        /// </summary>
        /// <returns>
        /// A collection of list items
        /// </returns>
        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        /// <summary>
        /// Update a category item in the database
        /// </summary>
        /// <param name="category">Modified Category item to be saved in database</param>
        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);

            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
