using Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Converters
{
    /// <summary>
    /// DishConverter
    /// </summary>
    public static class CategoryConverter
    {
        /// <summary>
        /// ModelToDto transformation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static CategoryDto ModelToDto(Category item)
        {
            if (item == null) return new CategoryDto();

            return new CategoryDto
            {
             CategoryId = item.Id,
             CategoryName = item.Name,
             //CategoryShowOrder = item.ShowOrder,
             CategoryDescripton = item.Description
            };
        }

    }
}
