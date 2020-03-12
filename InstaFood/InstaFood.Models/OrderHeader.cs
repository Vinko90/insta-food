/*
    Description: Order Header class
    
    Author: WarOfDevil          Date: 12-03-2020
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaFood.Models
{
    /// <summary>
    /// Order Header model class. Contain menu items database table definition
    /// </summary>
    public class OrderHeader
    {
        /// <summary>
        /// Order Header id, primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order user id, foreign key
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// ApplicationUser data record
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// The date of the order
        /// </summary>
        [Required]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// The money total of the order
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }

        /// <summary>
        /// Pick up time
        /// </summary>
        [Required]
        [Display(Name = "Pick up Time")]
        public DateTime PickUpTime { get; set; }

        /// <summary>
        /// Pickup date
        /// </summary>
        [Required]
        [Display(Name = "Pick up Date")]
        public DateTime PickUpDate { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Payment status
        /// </summary>
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Order comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// The name of the user who will pick up the order
        /// </summary>
        [Display(Name = "Pick up Name")]
        public string PickUpName { get; set; }

        /// <summary>
        /// The phone number of the user who will pick up the order
        /// </summary>
        [Display(Name = "Pick up Phone Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The payment transaction id
        /// </summary>
        public string TransactionId { get; set; }
    }
}
