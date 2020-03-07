/*
    Description: IUnitOfWork interface
    
    Author: WarOfDevil          Date: 27-02-2020
*/

using System;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// UnitOfWork Repository pattern interface.
    /// Declare repositories definition and save action
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Category Repository
        /// </summary>
        ICategoryRepository Category { get; }

        /// <summary>
        /// FoodType Repository
        /// </summary>
        IFoodTypeRepository FoodType { get; }

        /// <summary>
        /// MenuItem Repository
        /// </summary>
        IMenuItemRepository MenuItem { get; }

        /// <summary>
        /// ApplicationUser Repository
        /// </summary>
        IApplicationUserRepository ApplicationUser { get; }

        /// <summary>
        /// Save changes to database context
        /// </summary>
        void Save();
    }
}
