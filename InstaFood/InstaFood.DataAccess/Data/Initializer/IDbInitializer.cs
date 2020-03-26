/*
    Description: IDbInitializer interface
    
    Author: WarOfDevil          Date: 26-03-2020
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace InstaFood.DataAccess.Data.Initializer
{
    /// <summary>
    /// IDbInitializer Interface, create user roles on deployed application
    /// </summary>
    public interface IDbInitializer
    {
        /// <summary>
        /// Create roles and one administrator user in the database
        /// </summary>
        void Initialize();
    }
}
