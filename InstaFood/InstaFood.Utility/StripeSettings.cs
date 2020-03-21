/*
    Description: StripeSettings class
    
    Author: WarOfDevil          Date: 21-03-2020
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace InstaFood.Utility
{
    /// <summary>
    /// Stripe settings keys class. The properties are binded from user secret Json
    /// </summary>
    public class StripeSettings
    {
        /// <summary>
        /// Stripe public key
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Stripe Secret key
        /// </summary>
        public string SecretKey { get; set; }
    }
}
