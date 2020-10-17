using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data
{
	public class QuizDbContext : DbContext
	{
		public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
		{

		}

		public DbSet<Quiz> Quiz { get; set; }
	}
}
