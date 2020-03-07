/*
    Description: ApplicationUser class
    
    Author: WarOfDevil          Date: 06-03-2020
*/

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaFood.Models
{
    /// <summary>
    /// ApplicationUser Model class, extend .NET core Identity User table to 
    /// add custom fields into the table
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// User Fist Name
        /// </summary>
        [Display(Name = "Full Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// User Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Return a string containing user First name + Last Name
        /// </summary>
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
