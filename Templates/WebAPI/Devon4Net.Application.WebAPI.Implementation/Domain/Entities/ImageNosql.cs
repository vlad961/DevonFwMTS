using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class ImageNosql
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string mimeType { get; set; }
        public string content { get; set; }
     
    }
}