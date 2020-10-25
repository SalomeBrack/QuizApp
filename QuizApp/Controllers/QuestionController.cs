using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Controllers
{
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

		//GET - CREATE
		public IActionResult Create()
		{
			return View();
		}

		//POST - CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Question obj)
		{
			if (ModelState.IsValid)
			{
				_db.Question.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Play", obj);
			}
			return View(obj);
		}

		//GET - EDIT
		public IActionResult Edit(int id)
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

		//POST - EDIT
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Question obj)
		{
			if (ModelState.IsValid)
			{
				_db.Question.Update(obj);
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
			var obj = _db.Question.Find(id);
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
			var obj = _db.Question.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Question.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Play(int? id)
		{
			var obj = _db.Question.Find(id);
			return View(obj);
		}

		public IActionResult Results(int? id)
		{
			var obj = _db.Question.Find(id);
			return View(obj);
		}
	}
}
