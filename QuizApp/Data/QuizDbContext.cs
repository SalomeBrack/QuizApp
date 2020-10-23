using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data
{
	/*
	 * Package Manager Console:
	 * Add-Migration Quiz -Context QuizDbContext
	 * Update-Database -Context QuizDbContext
	*/

	public class QuizDbContext : DbContext
	{
		public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
		{

		}

		public DbSet<Quiz> Quiz { get; set; }
		public DbSet<Question> Question { get; set; }
	}
}
