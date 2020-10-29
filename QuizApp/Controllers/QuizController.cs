using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

		[HttpGet]
		public IActionResult Index(string? search)
		{
			IEnumerable<Quiz> objList = _db.Quiz;
			if (search != null && search != "")
			{
				objList = _db.Quiz.Where(q => q.Title.Contains(search));
			}
			return View(objList);
		}

		[HttpGet]
		public IActionResult CreateQuiz()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateQuiz(Quiz obj)
		{
			if (ModelState.IsValid)
			{
				_db.Quiz.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Edit", obj);
			}
			return View(obj);
		}

		[HttpGet]
		public IActionResult CreateQuestion(int? id)
		{
			if (id != null && id != 0)
			{
				Quiz obj = _db.Quiz.Find(id);
				Question obj2 = new Question() { QuizId = (int)id, Quest = "", Answ0 = "", Answ1 = "" };

				_db.Question.Add(obj2);
				_db.SaveChanges();

				return RedirectToAction("Edit", obj);
			}
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateQuestion(Question obj)
		{
			if (ModelState.IsValid)
			{
				_db.Question.Add(obj);
				_db.SaveChanges();

				Quiz obj2 = _db.Quiz.Find(obj.QuizId);
				return RedirectToAction("Edit", obj2);
			}
			return View(obj);
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			Quiz item1 = _db.Quiz.Find(id);
			IEnumerable<Question> item2 = _db.Question.Where(q => q.QuizId.Equals(id));
			Tuple<Quiz, IEnumerable<Question>> tuple = new Tuple<Quiz, IEnumerable<Question>>(item1, item2);

			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Quiz.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(tuple);
		}

		[HttpGet]
		public IActionResult EditQuiz(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Quiz.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditQuiz(Quiz obj)
		{
			if (ModelState.IsValid)
			{
				_db.Quiz.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Edit", obj);
			}

			return RedirectToAction("Edit", obj);
		}

		[HttpGet]
		public IActionResult DeleteQuiz(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Quiz.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		[HttpPost]
		public IActionResult DeleteQuizPost(int? id)
		{
			var obj = _db.Quiz.Find(id);
			var objList = _db.Question.Where(q => q.QuizId.Equals(id));
			if (obj == null)
			{
				return NotFound();
			}
			_db.Quiz.Remove(obj);
			_db.Question.RemoveRange(objList);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Play(int? id)
		{
			Quiz item1 = _db.Quiz.Find(id);
			IEnumerable<Question> item2 = _db.Question.Where(q => q.QuizId.Equals(id));
			Tuple<Quiz, IEnumerable<Question>> tuple = new Tuple<Quiz, IEnumerable<Question>>(item1, item2);
			return View(tuple);
		}

		[HttpGet]
		public IActionResult Results(int? id)
		{
			var obj = _db.Quiz.Find(id);
			return View(obj);
		}
	}
}
