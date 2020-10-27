using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

		//GET - CREATE
		public IActionResult AddQuestion(int? id)
		{
			Question obj = new Question() { QuizId = (int)id };
			return View(obj);
		}

		//POST - CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddQuestion(Question obj)
		{
			if (ModelState.IsValid)
			{
				_db.Question.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Edit", obj);
			}
			return View(obj);
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
				return RedirectToAction("Edit", obj);
			}
			return View(obj);
		}

		//GET - EDIT
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

		//POST - EDIT
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Quiz obj)
		{
			if (ModelState.IsValid)
			{
				_db.Quiz.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Play", obj);
			}
			return View(obj);
		}

		//GET - DELETE
		public IActionResult Delete(int? id)
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

		//POST - DELETE
		[HttpPost]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db.Quiz.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Quiz.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Play(int? id)
		{
			Quiz item1 = _db.Quiz.Find(id);
			IEnumerable<Question> item2 = _db.Question.Where(q => q.QuizId.Equals(id));
			Tuple<Quiz, IEnumerable<Question>> tuple = new Tuple<Quiz, IEnumerable<Question>>(item1, item2);
			return View(tuple);
		}

		public IActionResult Results(int? id)
		{
			var obj = _db.Quiz.Find(id);
			return View(obj);
		}
	}
}
