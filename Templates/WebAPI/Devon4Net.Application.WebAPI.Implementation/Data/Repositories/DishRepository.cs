using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Logger.Logging;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        private readonly IRepository<DishCategory> _dishCategoryRepository;
        private readonly IRepository<DishIngredient> _dishIngredientRepository;

        public DishRepository(
            ModelContext context,
            IRepository<DishCategory> dishCategoryRepository,
            IRepository<DishIngredient> dishIngredientRepository
            ) : base(context)
        {
            _dishCategoryRepository = dishCategoryRepository;
            _dishIngredientRepository = dishIngredientRepository;
        }
        
        public Task<Dish> GetDishById(long id)
        {
            Devon4NetLogger.Debug($"GetDishByID method from repository Dishservice with value : {id}");
            
            return GetFirstOrDefault(t => t.Id == id);
        }


        public async Task<IList<Dish>> GetAllNested(IList<string> nestedProperties, Expression<Func<Dish, bool>> predicate = null) 
        {
            return await Get(nestedProperties, predicate);
        }
    }
}