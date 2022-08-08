using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service;
using Devon4Net.Infrastructure.Log;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _DishService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="DishService"></param>
        public DishController(IDishService DishService)
        {
            _DishService = DishService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetDish()
        {
            Devon4NetLogger.Debug("Executing GetDish from controller DishController");

            // FILTER
            return Ok(await _DishService.GetDish().ConfigureAwait(false));
        }
        /*        public async Task<ActionResult> GetDishById(long id)
                {
                    Devon4NetLogger.Debug("Executing GetDishByID from controller DishController");
                    return Ok(await _DishService.GetDishById(id).ConfigureAwait(false));
                }*/


        [HttpPost]
        [HttpOptions]
        [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("/mythaistar/services/rest/Dishmanagement/v1/Dish/Search")]
        public async Task<IActionResult> DishSearch([FromBody] FilterDtoSearchObject filterDto)
        {
            Devon4NetLogger.Debug("Executing GetDish from controller DishController");

            Devon4NetLogger.Debug("Filter-properties: \n");
            Devon4NetLogger.Debug(JsonConvert.SerializeObject(filterDto));

            if (filterDto == null)
            {
                filterDto = new FilterDtoSearchObject { MaxPrice = "0", SearchBy = string.Empty };
            }

            decimal maxPrice = string.IsNullOrEmpty(filterDto.MaxPrice) ? 0 : Convert.ToDecimal(filterDto.MaxPrice);

            // FILTER
            return Ok(await _DishService.GetDishByFilter(maxPrice));
        }
    }
}
