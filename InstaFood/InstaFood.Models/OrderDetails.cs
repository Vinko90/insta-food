/*
    Description: Order Details class
    
    Author: WarOfDevil          Date: 12-03-2020
*/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaFood.Models
{
    /// <summary>
    /// Order Details model class. Contain menu items database table definition
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// Order details id, primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order id, foreign key
        /// </summary>
        [Required]
        public int OrderId { get; set; }

        /// <summary>
        /// Order header datarecord
        /// </summary>
        [ForeignKey("OrderId")]
        public virtual OrderHeader OrderHeader { get; set; }

        /// <summary>
        /// Menu Item id, foreign key
        /// </summary>
        [Required]
        public int MenuItemId { get; set; }

        /// <summary>
        /// Menu Item datarecord
        /// </summary>
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }

        /// <summary>
        /// Order count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Required]
        public double Price { get; set; }
    }
}
