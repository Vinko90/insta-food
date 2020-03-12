/*
    Description: ShoppingCartRepository class implementation
    
    Author: WarOfDevil          Date: 11-03-2020
*/

using InstaFood.Models;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Application User Repository pattern class.
    /// </summary>
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Costructor
        /// Initialize database context and send reference to Repository base class
        /// </summary>
        /// <param name="db">Database context</param>
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Decrement shopping item count
        /// </summary>
        /// <param name="shoppingCart">Shopping cart item</param>
        /// <param name="count">Count value</param>
        /// <returns>Decremented count number</returns>
        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        /// <summary>
        /// Increment shopping item count
        /// </summary>
        /// <param name="shoppingCart">Shopping cart item</param>
        /// <param name="count">Count value</param>
        /// <returns>Incremented count number</returns>
        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }
    }
}
