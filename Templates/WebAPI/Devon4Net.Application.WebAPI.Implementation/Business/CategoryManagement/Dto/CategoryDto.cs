using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Dto
{
    public partial class CategoryDto
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long CategoryShowOrder { get; set; }
        public string CategoryDescripton { get; set; }
    }
}
