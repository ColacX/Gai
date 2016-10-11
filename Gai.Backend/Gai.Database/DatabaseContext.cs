using Gai.Database.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gai.Database
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Name> Name { get; set; }
		public DbSet<Person> Person { get; set; }
		public DbSet<Phrase> Phrase { get; set; }
		public DbSet<Relation> Relation { get; set; }
		public DbSet<Time> Time { get; set; }
		public DbSet<Token> Token { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
