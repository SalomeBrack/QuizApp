using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
	public enum Type
	{
		Knowledge,
		Personality,
		Poll
	}

	public class Quiz
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }
		[Required]
		public Type Type { get; set; }

		public string UserId { get; set; }

		//public ICollection<Question> Questions { get; set; }
	}
}
