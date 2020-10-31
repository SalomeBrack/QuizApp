﻿using System;
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
			ViewData["Search"] = search;
			IEnumerable<Quiz> objList = _db.Quiz;
			if (search != null && search != "")
			{
				objList = _db.Quiz.Where(q => q.Title.Contains(search));
			}
			return View(objList);
		}

		[HttpGet]
		public IActionResult Play(int? id)
		{
			var item1 = _db.Quiz.Find(id);
			var item2 = _db.Question.Where(q => q.QuizId.Equals(id));
			var tuple = new Tuple<Quiz, IEnumerable<Question>>(item1, item2);
			return View(tuple);
		}

		[HttpGet]
		public IActionResult Results(int? id)
		{
			var obj = _db.Quiz.Find(id);
			return View(obj);
		}

		[HttpGet]
		public IActionResult Editor(int? id)
		{
			var item1 = _db.Quiz.Find(id);
			var item2 = _db.Question.Where(q => q.QuizId.Equals(id));
			var tuple = new Tuple<Quiz, IEnumerable<Question>>(item1, item2);
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
		public IActionResult Create()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int? id)
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

		[HttpGet]
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Quiz obj)
		{
			if (ModelState.IsValid)
			{
				_db.Quiz.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Editor", obj);
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Quiz obj)
		{
			if (ModelState.IsValid)
			{
				_db.Quiz.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Editor", obj);
			}

			return RedirectToAction("Editor", obj);
		}

		[HttpPost]
		public IActionResult DeletePost(int? id)
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
	}
}
