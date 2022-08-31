using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Dto
{
    public class DishNosqlDto
    {
        /// <summary>
        /// the Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// the Surname
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// the Mail
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        public ImageNosql Image { get; set; }
    }
}
