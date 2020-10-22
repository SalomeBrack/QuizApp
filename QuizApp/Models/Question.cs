using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
	public class Question
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Quiz { get; set; }
		[Required]
		public string Quest { get; set; }
		[Required]
		public string Answ0 { get; set; }
		[Required]
		public string Answ1 { get; set; }
		public string Answ2 { get; set; }
		public string Answ3 { get; set; }
	}
}
