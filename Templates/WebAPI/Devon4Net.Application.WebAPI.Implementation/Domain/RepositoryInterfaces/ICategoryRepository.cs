using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface ICategoryRepository : IRepository<Category> {
        Task<IList<Category>> GetCategory(Expression<Func<Category, bool>> predicate = null);
        Task<Category> GetCategoryById(long id);
    }

}