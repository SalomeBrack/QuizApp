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
		[Required]
		public string Name { get; set; }
		[Required]
		[Range(0, 2, ErrorMessage = "Value needs to be between 0 and 2")]
		public int Type { get; set; }
		[Required]
		public string Creator { get; set; }

		public ICollection<Question> Questions { get; set; }
	}
}
