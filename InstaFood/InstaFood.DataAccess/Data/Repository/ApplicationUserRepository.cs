/*
    Description: ApplicationUserRepository class implementation
    
    Author: WarOfDevil          Date: 07-03-2020
*/

using InstaFood.Models;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Application User Repository pattern class.
    /// </summary>
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Costructor
        /// Initialize database context and send reference to Repository base class
        /// </summary>
        /// <param name="db">Database context</param>
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
