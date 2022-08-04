using System.ComponentModel.DataAnnotations;
using Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Service;
using Devon4Net.Infrastructure.Log;
using Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devon4Net.Application.WebAPI.Implementation.Business.CategoryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="CategoryService"></param>
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCategory()
        {
            Devon4NetLogger.Debug("Executing GetCategory from controller CategoryController");
            return Ok(await _CategoryService.GetCategory().ConfigureAwait(false));
        }

    }
}
