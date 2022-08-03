using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto
{
    public partial class DishDto
    {
        public long DishId { get; set; }
        public string DishName { get; set; }
        public long DishIdImage { get; set; }
        public decimal DishPrice { get; set; }
        public string DishDescription { get; set; }
    }
}
