/*
    Description: MenuItem view model class
    
    Author: WarOfDevil          Date: 05-03-2020
*/

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InstaFood.Models.ViewModels
{
    /// <summary>
    /// Menu Item View Model
    /// </summary>
    public class MenuItemVM
    {
        /// <summary>
        /// A MenuItem object
        /// </summary>
        public MenuItem MenuItem { get; set; }

        /// <summary>
        /// Category list objects
        /// </summary>
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        /// <summary>
        /// FoodType list objects
        /// </summary>
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }
    }
}
