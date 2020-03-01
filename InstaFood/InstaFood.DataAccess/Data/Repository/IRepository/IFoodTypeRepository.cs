/*
    Description: IFoodTypeRepository interface
    
    Author: WarOfDevil          Date: 01-03-2020
*/

using InstaFood.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// FoodType Repository pattern interface.
    /// Declare repository pattern base methods with updates and custom select from a database context.
    /// </summary>

    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        /// <summary>
        /// Select all food type items from database
        /// </summary>
        /// <returns>
        /// A collection of list items
        /// </returns>
        IEnumerable<SelectListItem> GetFoodTypeListForDropDown();

        /// <summary>
        /// Update a food type item in the database
        /// </summary>
        /// <param name="foodType">Modified food type item to be saved in database</param>
        void Update(FoodType foodType);
    }
}
