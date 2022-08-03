using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
//            DishCategory = new HashSet<DishCategory>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ShowOrder { get; set; }
        /*
        public int? ModificationCounter { get; set; }


        public ICollection<DishCategory> DishCategory { get; set; }*/
    }
}
