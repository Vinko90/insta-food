/*
    Description: OrderDetailsRepository class implementation
    
    Author: WarOfDevil          Date: 12-03-2020
*/

using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using System.Linq;

namespace InstaFood.DataAccess.Data.Repository
{
    /// <summary>
    /// Order Details Repository pattern class.
    /// </summary>
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Costructor
        /// Initialize database context and send reference to Repository base class
        /// </summary>
        /// <param name="db">Database context</param>
        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Update a order details item in the database
        /// </summary>
        /// <param name="orderDetails">Modified order details item to be saved in database</param>
        public void Update(OrderDetails orderDetails)
        {
            var orderDetailsFromDb = _db.OrderDetails.FirstOrDefault(m => m.Id == orderDetails.Id);

            _db.OrderDetails.Update(orderDetailsFromDb);

            _db.SaveChanges();
        }
    }
}
