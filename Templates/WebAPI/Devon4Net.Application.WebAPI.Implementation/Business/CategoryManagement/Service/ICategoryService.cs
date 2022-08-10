using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Service
{
    /// <summary>
    /// TodoService interface
    /// </summary>
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategory(Expression<Func<Category, bool>> predicate = null);
        Task<Category> GetCategoryById(long id);
    }
}
