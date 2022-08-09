using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service;
using Devon4Net.Infrastructure.Log;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Converters;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

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
        [AllowAnonymous]
        [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("/mythaistar/services/rest/dishmanagement/v1/dish/search")]
        public async Task<IActionResult> DishSearch([FromBody] FilterDtoSearchObjectDto filterDto)
        {
            Devon4NetLogger.Debug("Executing GetDish from controller DishController");

            Devon4NetLogger.Debug("Filter-properties: \n");
            Devon4NetLogger.Debug(JsonConvert.SerializeObject(filterDto));

            if (filterDto == null)
            {
                filterDto = new FilterDtoSearchObjectDto { MaxPrice = 0, SearchBy = string.Empty };
            }

            // I guess this was one of the more recent changes in the frontend.
            // Most queries with numbers are now actually parsed in json as numbers
            decimal maxPrice = filterDto.MaxPrice.GetValueOrDefault(0); //string.IsNullOrEmpty(filterDto.MaxPrice) ? 0 : Convert.ToDecimal(filterDto.MaxPrice);

            var dishQueryResult = await _DishService.GetDish();

            var criteria = filterDto.SearchBy ?? String.Empty;

            if (!string.IsNullOrWhiteSpace(criteria))
            {
                dishQueryResult = dishQueryResult.Where(e => e.Name.Contains(criteria)).ToList();
            }

            if (maxPrice > 0)
            {
                dishQueryResult = dishQueryResult.Where(e => e.Price < maxPrice).ToList();
            }

            Int32 minLikes = Convert.ToInt32(filterDto.MinLikes.GetValueOrDefault(0));

            if (minLikes > 0)
            {
                   
            }

            var result = new ResultObjectDto<DishDtoResult> {};

            result.Result = dishQueryResult.Select(DishConverter.EntityToApi).ToList();

            return new ObjectResult(JsonConvert.SerializeObject(result));
        }
    }
}
