/*
    Description: FoodType class
    
    Author: WarOfDevil          Date: 01-03-2020
*/

using System.ComponentModel.DataAnnotations;

namespace InstaFood.Models
{
    /// <summary>
    /// Food type model class. Contain category database table definition
    /// </summary>
    public class FoodType
    {
        /// <summary>
        /// Food type Id primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Food type name
        /// </summary>
        [Required]
        [Display(Name = "Food Type Name")]
        public string Name { get; set; }
    }
}
