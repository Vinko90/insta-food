/*
    Description: ICategoryRepository interface
    
    Author: WarOfDevil          Date: 27-02-2020
*/

using System.Collections.Generic;
using InstaFood.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Category Repository pattern interface.
    /// Declare repository pattern base methods with updates and custom select from a database context.
    /// </summary>
    public interface ICategoryRepository : IRepository<Category>
    {
        /// <summary>
        /// Select all category items from database
        /// </summary>
        /// <returns>
        /// A collection of list items
        /// </returns>
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        /// <summary>
        /// Update a category item in the database
        /// </summary>
        /// <param name="category">Modified Category item to be saved in database</param>
        void Update(Category category);
    }
}
