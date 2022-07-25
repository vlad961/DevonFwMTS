using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Database
{
    public class DishContext : DbContext
    {
        public DishContext(DbContextOptions<DishContext> options) 
            : base(options)
        {
        }
        
        public virtual DbSet<Dish> Dish { get; set; }
    }
}