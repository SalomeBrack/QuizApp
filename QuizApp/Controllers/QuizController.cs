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

		//GET - CREATE
		public IActionResult Create()
		{
			return View();
		}

		//POST - CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Quiz obj)
		{
			if (ModelState.IsValid)
			{
				_db.Quiz.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}
	}
}
