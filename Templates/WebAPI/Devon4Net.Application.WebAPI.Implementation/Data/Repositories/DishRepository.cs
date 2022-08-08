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
        private readonly IRepository<DishCategory> _dishCategoryRepository;

        public DishRepository(
            ModelContext context,
            IRepository<DishCategory> dishCategoryRepository
            ) : base(context)
        {
            _dishCategoryRepository = dishCategoryRepository;
        }

        public async Task<IList<Dish>> GetAll(Expression<Func<Dish, bool>> predicate = null)
        {
            var result = await Get(predicate).ConfigureAwait(false);

            foreach (var dish in result)
            {
                dish.DishCategory = await _dishCategoryRepository.Get(c => c.IdDish == dish.Id);
            }

            return result;
        }
        public Task<Dish> GetDishById(long id)
        {
            Devon4NetLogger.Debug($"GetDishByID method from repository Dishservice with value : {id}");
            return GetFirstOrDefault(t => t.Id == id);
        }

    }
}