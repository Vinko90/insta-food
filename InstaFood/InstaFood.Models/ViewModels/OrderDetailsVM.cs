/*
    Description: Order details view model class
    
    Author: WarOfDevil          Date: 26-03-2020
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace InstaFood.Models.ViewModels
{
    /// <summary>
    /// Order details view model class implementation
    /// </summary>
    public class OrderDetailsVM
    {
        /// <summary>
        /// Order Header object
        /// </summary>
        public OrderHeader OrderHeader { get; set; }

        /// <summary>
        /// List of OrderDetails objects
        /// </summary>
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
