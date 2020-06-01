using Microsoft.AspNetCore.Mvc;
using Q.DataAccess;
using Q.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IBaseRepository<Video> _videoRepository;

        public VideoController(IBaseRepository<Video> videoRepository)
        {
            _videoRepository = videoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> Get()
        {
            var items = await _videoRepository.GetAllAsync();
            return Ok(items);
        }

        public async Task<ActionResult<Video>> Get(int id)
        {
            Video video;
            var item = await _videoRepository.FilterAll(nameof(video.CategoryId),id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

    }
}
