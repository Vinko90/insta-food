/*
    Description: Category class
    
    Author: WarOfDevil          Date: 27-02-2020
*/

using System.ComponentModel.DataAnnotations;

namespace InstaFood.Models
{
    /// <summary>
    /// Category model class. Contain category database table definition
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category Id primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        [Required]
        [Display(Name="Category Name")]
        public string Name { get; set; }

        /// <summary>
        /// Category display order
        /// </summary>
        [Required]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

    }
}
