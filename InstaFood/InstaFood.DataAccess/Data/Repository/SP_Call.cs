/*
    Description: ISP_Call class
    
    Author: WarOfDevil          Date: 26-03-2020
*/

using Dapper;
using InstaFood.DataAccess.Data.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaFood.DataAccess.Data.Repository
{
    /// <summary>
    /// SQL Store Procedure calls class implementation
    /// </summary>
    public class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";

        /// <summary>
        /// Default costructor
        /// </summary>
        /// <param name="db">ApplicationDbContext database</param>
        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = _db.Database.GetDbConnection().ConnectionString;
        }

        /// <summary>
        /// Dispose objects
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }

        /// <summary>
        /// Execute a StoredProcedure and return an object
        /// </summary>
        /// <typeparam name="T">Object of any type</typeparam>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="param">Parameter</param>
        /// <returns>An object of any type</returns>
        public T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        /// <summary>
        /// Execute a StoredProcedure without returning anything
        /// </summary>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="param">Parameter</param>
        public void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Return a list from StoredProcedure
        /// </summary>
        /// <typeparam name="T">Object of any type</typeparam>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="param">Parameter</param>
        /// <returns>An Enumerable of any type</returns>
        public IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
