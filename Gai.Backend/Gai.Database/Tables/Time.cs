﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gai.Database.Tables
{
	public class Time
	{
		[Key]
		public long Id { get; set; }

		[Index]
		public DateTime TimeData { get; set; }

		[Index]
		public long Relation_Id { get; set; }

		[ForeignKey("Relation_Id")]
		public virtual Relation Relation { get; set; }
	}
}
