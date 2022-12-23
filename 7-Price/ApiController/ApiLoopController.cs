using NewsParser.Services;
using Microsoft.AspNetCore.Mvc;
using NewsParser.Models;

namespace NewsParser.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiLoopController : ControllerBase
    {
        private readonly ParserService _service;


        public ApiLoopController (ParserService service)
        {
            _service = service;
        }

        [HttpGet("start")]
        public async Task Start()
        {
            await _service.ParseNews();
        }
    }
}
