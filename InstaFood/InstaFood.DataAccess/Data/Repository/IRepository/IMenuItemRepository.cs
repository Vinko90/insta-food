/*
    Description: IMenuItemRepository interface
    
    Author: WarOfDevil          Date: 05-03-2020
*/

using InstaFood.Models;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Menu Items Repository pattern interface.
    /// Declare repository pattern base methods with updates and custom select from a database context.
    /// </summary>
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        /// <summary>
        /// Update a menu item in the database
        /// </summary>
        /// <param name="menuItem">Modified Menu item to be saved in database</param>
        void Update(MenuItem menuItem);
    }
}
