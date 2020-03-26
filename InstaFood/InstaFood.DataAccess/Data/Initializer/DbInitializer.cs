/*
    Description: DbInitializer class
    
    Author: WarOfDevil          Date: 26-03-2020
*/

using InstaFood.Models;
using InstaFood.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaFood.DataAccess.Data.Initializer
{
    /// <summary>
    /// IDbInitializer class, create user roles on deployed application
    /// </summary>
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Default costructor
        /// </summary>
        /// <param name="db">ApplicationDb Contex</param>
        /// <param name="userManager">Identity User</param>
        /// <param name="roleManager">Identity Role</param>
        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        /// <summary>
        /// Create roles and one administrator user in the database
        /// </summary>
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex)
            {
            }

            if (!_db.Roles.Any(r => r.Name == StaticDetails.ManagerRole))
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.ManagerRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.FrontDeskRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.KitchenRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.CustomerRole)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    FirstName = "Administrator",
                    LastName = "Administrator"
                }, "Admin_123").GetAwaiter().GetResult();

                ApplicationUser adminUser = _db.ApplicationUser.Where(u => u.Email == "admin@admin.com").FirstOrDefault();

                _userManager.AddToRoleAsync(adminUser, StaticDetails.ManagerRole).GetAwaiter().GetResult();
            }          
        }
    }
}
