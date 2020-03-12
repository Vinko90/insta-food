/*
    Description: IShoppingCartRepository interface
    
    Author: WarOfDevil          Date: 11-03-2020
*/

using InstaFood.Models;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Shopping cart Repository pattern interface.
    /// Declare repository pattern base methods with updates and custom select from a database context.
    /// </summary>
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        /// <summary>
        /// Increment shopping item count
        /// </summary>
        /// <param name="shoppingCart">Shopping cart item</param>
        /// <param name="count">Count value</param>
        /// <returns>Incremented count number</returns>
        int IncrementCount(ShoppingCart shoppingCart, int count);

        /// <summary>
        /// Decrement shopping item count
        /// </summary>
        /// <param name="shoppingCart">Shopping cart item</param>
        /// <param name="count">Count value</param>
        /// <returns>Decremented count number</returns>
        int DecrementCount(ShoppingCart shoppingCart, int count);
    }
}
