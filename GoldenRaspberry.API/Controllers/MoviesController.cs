using GoldenRaspberry.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoldenRaspberry.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieAppService _movieAppService;

        public MoviesController(IMovieAppService movieAppService)
        {
            _movieAppService = movieAppService;
        }

        [HttpGet("producer-metrics")]
        public IActionResult GetProducerMetrics()
        {
            var result = _movieAppService.GetProducerMetrics();
            return Ok(result);
        }
    }
}
