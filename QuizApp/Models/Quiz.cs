using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
	public class Quiz
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Type { get; set; }
		public string Creator { get; set; }
	}
}
