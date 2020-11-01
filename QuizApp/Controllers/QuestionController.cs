using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Controllers
{
	[Authorize]
	public class QuestionController : Controller
	{
		private readonly QuizDbContext _db;

		public QuestionController(QuizDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Question> objList = _db.Question;
			return View(objList);
		}

		[HttpGet]
		public IActionResult Create(int? quizId)
		{
			ViewData["QuizId"] = quizId;
			if (quizId != null && quizId != 0)
			{
				return View();
			}
			return RedirectToAction("Index", "Quiz");
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Question.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Question.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Question obj)
		{
			if (ModelState.IsValid)
			{
				_db.Question.Add(obj);
				_db.SaveChanges();

				Quiz obj2 = _db.Quiz.Find(obj.QuizId);
				return RedirectToAction("Editor", "Quiz", obj2);
			}
			return View(); //TODO: quizId als parameter mitgeben
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Question objQuestion)
		{
			var objQuiz = _db.Quiz.Find(objQuestion.QuizId);
			if (ModelState.IsValid)
			{
				_db.Question.Update(objQuestion);
				_db.SaveChanges();
				return RedirectToAction("Editor", "Quiz", objQuiz);
			}
			return RedirectToAction("Editor", "Quiz", objQuiz);
		}

		[HttpPost]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db.Question.Find(id);
			var obj2 = _db.Quiz.Find(obj.QuizId);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Question.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Editor", "Quiz", obj2);
		}
	}
}
