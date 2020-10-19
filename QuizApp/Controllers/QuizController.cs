using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Controllers
{
	public class QuizController : Controller
	{
		private readonly QuizDbContext _db;

		public QuizController(QuizDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Quiz> objList = _db.Quiz;
			return View(objList);
		}
	}
}
