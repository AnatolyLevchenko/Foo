using Microsoft.AspNetCore.Mvc;
using Q.DataAccess;
using Q.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseRepository<Category> _categoryRepository;

        public CategoryController(IBaseRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var items = await _categoryRepository.GetAllAsync();
            return Ok(items);
        }
    }
}