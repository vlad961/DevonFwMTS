using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Database.Sqlite
{
	public class ModelContextSqliteFactory : IDesignTimeDbContextFactory<ModelContextSqlite>
	{
		public ModelContextSqlite CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ModelContextSqlite>();
			optionsBuilder.UseSqlite("DataSource=Templates\\WebAPI\\Devon4Net.Application.WebAPI.Implementation\\sqlite.db");
			return new ModelContextSqlite(optionsBuilder.Options);
		}
	}
}
