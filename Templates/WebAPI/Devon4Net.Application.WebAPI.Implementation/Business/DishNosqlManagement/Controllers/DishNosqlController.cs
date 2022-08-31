using Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Converters;
using Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class DishNosqlController: Controller
    {
        private readonly IDishNosqlService _dishNosqlService;

        public DishNosqlController(IDishNosqlService dishServiceNosql)
        {
            _dishNosqlService = dishServiceNosql;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DishNosqlDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("/mythaistar/services/rest/dishmanagement/v2/dish")]
        public async Task<List<DishNosqlDto>> Get()
        {
            var result = await _dishNosqlService.GetAsync();
            foreach (var item in result)
            {
                Console.WriteLine("YASH:" + item);
            }

            return result.Select(DishNosqlConverter.ModelToDto).ToList();
        }
    }
}
