﻿/*
    Description: ApplicationDbContext class
    
    Author: WarOfDevil          Date: 27-02-2020
*/

using InstaFood.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstaFood.DataAccess
{
	/// <summary>
	/// ApplicationDbContext class
	/// Initialize EF database, inherit settings for user Identity
	/// </summary>
	public class ApplicationDbContext : IdentityDbContext
	{
		/// <summary>
		/// Category table
		/// </summary>
		public DbSet<Category> Category {get; set;}

		/// <summary>
		/// FoodType table
		/// </summary>
		public DbSet<FoodType> FoodType { get; set; }

		/// <summary>
		/// MenuItem table
		/// </summary>
		public DbSet<MenuItem> MenuItem { get; set; }

		/// <summary>
		/// Default costructor
		/// </summary>
		/// <param name="options">Database connection options</param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}
}
