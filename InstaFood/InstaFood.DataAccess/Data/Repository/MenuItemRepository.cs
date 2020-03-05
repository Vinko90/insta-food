/*
    Description: MenuItemRepository class implementation
    
    Author: WarOfDevil          Date: 05-03-2020
*/

using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using System.Linq;

namespace InstaFood.DataAccess.Data.Repository
{
    /// <summary>
    /// MenuItem Repository pattern class.
    /// </summary>
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Costructor
        /// Initialize database context and send reference to Repository base class
        /// </summary>
        /// <param name="db">Database context</param>
        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Update a menu item in the database
        /// </summary>
        /// <param name="menuItem">Modified Menu item to be saved in database</param>
        public void Update(MenuItem menuItem)
        {
            var menuItemFromDb = _db.MenuItem.FirstOrDefault(m => m.Id == menuItem.Id);

            menuItemFromDb.Name = menuItem.Name;
            menuItemFromDb.CategoryId = menuItem.CategoryId;
            menuItemFromDb.Description = menuItem.Description;
            menuItemFromDb.FoodTypeId = menuItem.FoodTypeId;
            menuItemFromDb.Price = menuItem.Price;

            if (menuItem.Image != null)
            {
                menuItemFromDb.Image = menuItem.Image;
            }

            _db.SaveChanges();           
        }
    }
}
