/*
    Description: UnitOfWork class implementation
    
    Author: WarOfDevil          Date: 27-02-2020
*/

using InstaFood.DataAccess.Data.Repository.IRepository;

namespace InstaFood.DataAccess.Data.Repository
{
    /// <summary>
    /// UnitOfWork Repository pattern class implementation.
    /// Implement repositories definition and save action
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }

        public IFoodTypeRepository FoodType { get; private set; }

        public IMenuItemRepository MenuItem { get; private set; }

        /// <summary>
        /// Constructor, initialize all the repository and attach them database context
        /// </summary>
        /// <param name="db">Database contex</param>
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            FoodType = new FoodTypeRepository(_db);
            MenuItem = new MenuItemRepository(_db);
        }

        /// <summary>
        /// Save changes to database context
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }

        /// <summary>
        /// Dispose UnitOfWork object
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
