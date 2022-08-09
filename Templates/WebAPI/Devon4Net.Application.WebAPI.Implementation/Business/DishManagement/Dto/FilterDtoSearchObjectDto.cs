using Newtonsoft.Json;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto
{
    public class FilterDtoSearchObjectDto
    {
        [JsonProperty(PropertyName = "categories")]
        public CategorySearchDto[] Categories { get; set; }

        [JsonProperty(PropertyName = "searchBy")]
        public string SearchBy { get; set; }

        [JsonProperty(PropertyName = "maxPrice")]
        public Decimal? MaxPrice { get; set; }

        [JsonProperty(PropertyName = "minLikes")]
        public Decimal? MinLikes { get; set; }
    }
}
