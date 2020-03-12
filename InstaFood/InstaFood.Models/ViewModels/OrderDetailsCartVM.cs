/*
    Description: OrderDetailsCart view model class
    
    Author: WarOfDevil          Date: 12-03-2020
*/

using System.Collections.Generic;

namespace InstaFood.Models.ViewModels
{
    /// <summary>
    /// Order Details Shopping Cart View Model
    /// </summary>
    public class OrderDetailsCartVM
    {
        /// <summary>
        /// List of shopping cart
        /// </summary>
        public List<ShoppingCart> ListCart { get; set; }

        /// <summary>
        /// Order header
        /// </summary>
        public OrderHeader OrderHeader { get; set; }
    }
}
