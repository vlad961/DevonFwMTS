using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Service
{
    /// <summary>
    /// DishNosqlService interface
    /// </summary>
    public interface IDishNosqlService
    {
        Task<List<DishNosql>> GetAsync();
    }
}
