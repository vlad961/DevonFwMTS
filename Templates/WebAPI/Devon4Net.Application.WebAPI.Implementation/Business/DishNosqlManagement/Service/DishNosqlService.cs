using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Service
{
    public class DishNosqlService: IDishNosqlService
    {
        private readonly IDishNosqlRepository _dishNosqlRepository;

        public DishNosqlService(IDishNosqlRepository dishNosqlRepository)
        {
            _dishNosqlRepository = dishNosqlRepository;
        }

        public async Task<List<DishNosql>> GetAsync() =>
        await _dishNosqlRepository.GetAll();
    }
}
