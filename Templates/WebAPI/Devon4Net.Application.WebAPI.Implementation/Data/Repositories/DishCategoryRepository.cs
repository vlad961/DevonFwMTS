using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Logger.Logging;
using Devon4Net.Application.WebAPI.Implementation.Business.TodoManagement.Validators;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class DishCategoryRepository : Repository<DishCategory>, IDishCategoryRepository
    {
        public DishCategoryRepository(ModelContext context) : base(context)
        {
        }

        public Task<IList<DishCategory>> GetAll(Expression<Func<DishCategory, bool>> predicate = null)
        {
            return Get(predicate);
        }
    }
}
