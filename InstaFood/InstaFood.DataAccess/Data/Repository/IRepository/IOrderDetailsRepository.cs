/*
    Description: IOrderDetailsRepository interface
    
    Author: WarOfDevil          Date: 12-03-2020
*/

using InstaFood.Models;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Order Details Repository pattern interface.
    /// Declare repository pattern base methods with updates and custom select from a database context.
    /// </summary>
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        /// <summary>
        /// Update a order details item in the database
        /// </summary>
        /// <param name="orderDetails">Modified order details item to be saved in database</param>
        void Update(OrderDetails orderDetails);
    }
}
