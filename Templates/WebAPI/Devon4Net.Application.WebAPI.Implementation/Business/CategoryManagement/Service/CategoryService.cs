using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Logger.Logging;
using Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Converters;
using Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Service
{
    /// <summary>
    /// Service implementation
    /// </summary>
    public class CategoryService: Service<CategoryContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryService(IUnitOfWork<CategoryContext> uoW) : base(uoW)
        {
            _categoryRepository = uoW.Repository<ICategoryRepository>();
        }

        public async Task<IEnumerable<CategoryDto>> GetCategory(Expression<Func<Category, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetCategory from CategoryService");
            var result = await _categoryRepository.GetCategory(predicate).ConfigureAwait(false);
            return result.Select(CategoryConverter.ModelToDto);
        }
        public Task<Category> GetCategoryById(long id)
        {
            Devon4NetLogger.Debug($"GetCategoryById method from service Categoryservice with value : {id}");
            return _categoryRepository.GetCategoryById(id);
        }
    }
}