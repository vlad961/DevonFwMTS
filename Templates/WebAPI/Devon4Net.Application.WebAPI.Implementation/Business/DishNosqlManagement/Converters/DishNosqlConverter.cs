using Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Converters
{
    public class DishNosqlConverter
    {
        /// <summary>
        /// ModelToDto transformation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static DishNosqlDto ModelToDto(DishNosql item)
        {
            if (item == null) return new DishNosqlDto();

            return new DishNosqlDto
            {
                Id = item._id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Image = item.Image
            };
        }
    }
}
