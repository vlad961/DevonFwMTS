using System.ComponentModel.DataAnnotations;
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
            return Ok(await _DishService.GetDish().ConfigureAwait(false));
        }
    }
}
