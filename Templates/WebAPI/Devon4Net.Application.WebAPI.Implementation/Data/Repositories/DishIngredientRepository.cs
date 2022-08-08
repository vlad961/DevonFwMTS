using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Log;
using Devon4Net.Application.WebAPI.Implementation.Business.TodoManagement.Validators;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class DishIngredientRepository : Repository<DishIngredient>, IDishIngredientRepository
    {
        public DishIngredientRepository(ModelContext context) : base(context)
        {
        }

        public Task<IList<DishIngredient>> GetAll(Expression<Func<DishIngredient, bool>> predicate = null)
        {
            return Get(predicate);
        }
    }
}
