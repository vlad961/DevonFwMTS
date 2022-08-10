using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IDishIngredientRepository : IRepository<DishIngredient> {
        Task<IList<DishIngredient>> GetAll(Expression<Func<DishIngredient, bool>> predicate = null);
    }
}