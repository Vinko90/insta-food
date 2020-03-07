/*
    Description: ShoppingCart class
    
    Author: WarOfDevil          Date: 07-03-2020
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaFood.Models
{
    /// <summary>
    /// ShoppingCart Model class.
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Shopping cart Id primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Menu item id, foreign key
        /// </summary>
        public int MenuItemId { get; set; }

        /// <summary>
        /// Menu Item object from foreign key id
        /// </summary>
        [NotMapped]
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }

        /// <summary>
        /// Application User id, foreign key
        /// </summary>
        public string ApplicationUserId { get; set; }

        /// <summary>
        /// Application User object from foreign key id
        /// </summary>
        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Product count number
        /// </summary>
        [Range(1,100,ErrorMessage = "Please select a number between 1 and 100")]
        public int Count { get; set; }

        /// <summary>
        /// Default constructor, init the counter to start from 1
        /// </summary>
        public ShoppingCart()
        {
            Count = 1;
        }

    }
}
