using Newtonsoft.Json;
using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto
{

    public class ResultObjectDto<T>
    {
        /*
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }
        [JsonProperty(PropertyName = "result")]
        */
        public List<T> Result { get; set; }

        public ResultObjectDto()
        {
            //Pagination = new Pagination();
            Result = new List<T>();
        }
    }

}