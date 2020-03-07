/*
    Description: IApplicationUserRepository interface
    
    Author: WarOfDevil          Date: 07-03-2020
*/

using InstaFood.Models;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Application user Repository pattern interface.
    /// Declare repository pattern base methods with updates and custom select from a database context.
    /// </summary>
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
    }
}
