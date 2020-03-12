/*
    Description: IOrderHeaderRepository interface
    
    Author: WarOfDevil          Date: 12-03-2020
*/

using InstaFood.Models;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Order Header Repository pattern interface.
    /// Declare repository pattern base methods with updates and custom select from a database context.
    /// </summary>
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        /// <summary>
        /// Update a order header item in the database
        /// </summary>
        /// <param name="orderHeader">Modified order header item to be saved in database</param>
        void Update(OrderHeader orderHeader);
    }
}
