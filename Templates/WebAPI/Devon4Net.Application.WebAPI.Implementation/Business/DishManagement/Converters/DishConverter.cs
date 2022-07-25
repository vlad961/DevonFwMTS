using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Converters
{
    /// <summary>
    /// DishConverter
    /// </summary>
    public static class DishConverter
    {
        /// <summary>
        /// ModelToDto transformation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static DishDto ModelToDto(Dish item)
        {
            if (item == null) return new DishDto();

            return new DishDto
            {
                Id = item.Id,
                Name = item.Name
            };
        }

    }
}
