using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Log;
using Devon4Net.Application.WebAPI.Implementation.Business.TodoManagement.Validators;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(DishContext context) : base(context)
        {
        }

        public Task<IList<Dish>> GetDish(Expression<Func<Dish, bool>> predicate = null)
        {
            return Get(predicate);
        }
    }
}