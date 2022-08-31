using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IDishNosqlRepository
    {
        Task<List<DishNosql>> GetAll();
    }
}
