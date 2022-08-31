using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Database
{
    public class ModelContextFactory: IDesignTimeDbContextFactory<ModelContext>
    {
		public ModelContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
			optionsBuilder.UseSqlServer("Server=Server=127.0.0.1,1433;Database=MicrosoftSqlServer;User=sa;Password=C@pgemini2017");

			return new ModelContext(optionsBuilder.Options);
		}
	}
}
