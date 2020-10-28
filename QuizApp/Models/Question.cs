using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
	public class Question
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[DisplayName("Question")]
		[Required]
		public string Quest { get; set; }
		[DisplayName("Correct Answer")]
		[Required]
		public string Answ0 { get; set; }
		[DisplayName("Wrong Answer")]
		[Required]
		public string Answ1 { get; set; }
		[DisplayName("Wrong Answer")]
		public string Answ2 { get; set; }
		[DisplayName("Wrong Answer")]
		public string Answ3 { get; set; }

		[Required]
		public int QuizId { get; set; }
		// public Quiz Quiz { get; set; }
	}
}
