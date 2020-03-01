/*
    Description: FoodTypeRepository class implementation
    
    Author: WarOfDevil          Date: 01-03-2020
*/

using InstaFood.DataAccess.Data.Repository.IRepository;
using InstaFood.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace InstaFood.DataAccess.Data.Repository
{
    /// <summary>
    /// FoodType Repository pattern class.
    /// </summary>
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Costructor
        /// Initialize database context and send reference to Repository base class
        /// </summary>
        /// <param name="db">Database context</param>
        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Select all food type items from database
        /// </summary>
        /// <returns>
        /// A collection of list items
        /// </returns>
        public IEnumerable<SelectListItem> GetFoodTypeListForDropDown()
        {
            return _db.FoodType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        /// <summary>
        /// Update a food type item in the database
        /// </summary>
        /// <param name="foodType">Modified FoodType item to be saved in database</param>
        public void Update(FoodType foodType)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(s => s.Id == foodType.Id);

            objFromDb.Name = foodType.Name;

            _db.SaveChanges();
        }
    }
}
