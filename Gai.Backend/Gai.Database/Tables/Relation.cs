using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gai.Database.Tables
{
	public class Relation
	{
		[Key]
		public long Id { get; set; }

		[Index]
		public float Weight { get; set; }
	}
}
