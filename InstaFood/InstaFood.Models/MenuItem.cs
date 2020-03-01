/*
    Description: Menu Item class
    
    Author: WarOfDevil          Date: 01-03-2020
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaFood.Models
{
    /// <summary>
    /// Menu Item model class. Contain menu items database table definition
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Menu Item Id primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Menu Item Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Menu Item Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Menu Item Description.
        /// Save the server path of the image in the database
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Menu Item price.
        /// Minimum value is 1$ and maximum value is Integer.MaxValue
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than $1")]
        public double Price { get; set; }

        /// <summary>
        /// The Category Id foreign key to bind the menu item with
        /// </summary>
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Category element
        /// </summary>
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        /// <summary>
        /// The FoodItem Id foreign key to bind the menu item with
        /// </summary>
        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }

        /// <summary>
        /// FoodType element
        /// </summary>
        [ForeignKey("FoodTypeId")]
        public virtual FoodType FoodType { get; set; }
    }
}
