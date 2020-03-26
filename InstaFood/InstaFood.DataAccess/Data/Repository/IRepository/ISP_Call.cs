/*
    Description: ISP_Call interface
    
    Author: WarOfDevil          Date: 26-03-2020
*/

using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaFood.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// SQL Store Procedure calls interface using Dapper
    /// </summary>
    public interface ISP_Call : IDisposable
    {
        /// <summary>
        /// Return a list from StoredProcedure
        /// </summary>
        /// <typeparam name="T">Object of any type</typeparam>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="param">Parameter</param>
        /// <returns>An Enumerable of any type</returns>
        IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null);

        /// <summary>
        /// Execute a StoredProcedure without returning anything
        /// </summary>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="param">Parameter</param>
        void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null);

        /// <summary>
        /// Execute a StoredProcedure and return an object
        /// </summary>
        /// <typeparam name="T">Object of any type</typeparam>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="param">Parameter</param>
        /// <returns>An object of any type</returns>
        T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null);
    }
}
