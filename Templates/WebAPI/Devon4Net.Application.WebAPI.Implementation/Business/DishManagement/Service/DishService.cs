using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Log;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service
{
    /// <summary>
    /// Service implementation
    /// </summary>
    public class DishService : Service<ModelContext>, IDishService
    {
        private readonly IDishRepository _dishRepository;

        
        public DishService(IUnitOfWork<ModelContext> uoW) : base(uoW)
        {
            _dishRepository = uoW.Repository<IDishRepository>();
        }

        public async Task<List<Dish>> GetDish(decimal maxPrice, int minLikes, string searchBy)
        {
            Devon4NetLogger.Debug("GetDish from DishService");

            var includes = new List<string>
            {
                "DishCategory",
                "DishCategory.IdCategoryNavigation", 
                "DishIngredient",
                "DishIngredient.IdIngredientNavigation",
                "IdImageNavigation"
            };

            var result = await _dishRepository.GetAllNested(includes).ConfigureAwait(false);

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                result = result.Where(e => e.Name.Contains(searchBy)).ToList();
            }

            if (maxPrice > 0)
            {
                result = result.Where(e => e.Price < maxPrice).ToList();
            }

            if (minLikes > 0)
            {
                   
            }

            return result.ToList();
        }

        public Task<Dish> GetDishById(long id)
        {
            Devon4NetLogger.Debug($"GetDishById method from service Dishservice with value : {id}");
            
            return _dishRepository.GetDishById(id);
        }
    }
}