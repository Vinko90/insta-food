/*
    Description: OrderHeaderRepository class implementation
    
    Author: WarOfDevil          Date: 12-03-2020
*/

using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using System.Linq;

namespace InstaFood.DataAccess.Data.Repository
{
    /// <summary>
    /// Order Header Repository pattern class.
    /// </summary>
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Costructor
        /// Initialize database context and send reference to Repository base class
        /// </summary>
        /// <param name="db">Database context</param>
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Update a order header item in the database
        /// </summary>
        /// <param name="orderHeader">Modified order header item to be saved in database</param>
        public void Update(OrderHeader orderHeader)
        {
            var orderHeaderFromDb = _db.OrderHeader.FirstOrDefault(m => m.Id == orderHeader.Id);

            _db.OrderHeader.Update(orderHeaderFromDb);

            _db.SaveChanges();
        }
    }
}
