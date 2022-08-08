using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Log;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Converters;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto;
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

        public async Task<IEnumerable<DishDto>> GetDish(Expression<Func<Dish, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetDish from DishService");
            var result = await _dishRepository.GetAll(predicate).ConfigureAwait(false);

            foreach (var dish in result)
            {
                foreach (var category in dish.DishCategory)
                {
                    Console.WriteLine(category.Id);
                    Console.WriteLine(category.IdCategory);
                }
            }
     
            return result.Select(DishConverter.ModelToDto);
        }
        public Task<Dish> GetDishById(long id)
        {
            Devon4NetLogger.Debug($"GetDishById method from service Dishservice with value : {id}");
            return _dishRepository.GetDishById(id);
        }
    }
}