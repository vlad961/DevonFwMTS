using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Logger.Logging;
using Devon4Net.Application.WebAPI.Implementation.Business.TodoManagement.Validators;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CategoryContext context) : base(context)
        {
        }

        public Task<IList<Category>> GetCategory(Expression<Func<Category, bool>> predicate = null)
        {
            return Get(predicate);
        }
        public Task<Category> GetCategoryById(long id)
        {
            Devon4NetLogger.Debug($"GetDishByID method from repository Dishservice with value : {id}");
            return GetFirstOrDefault(t => t.Id == id);
        }

    }
}