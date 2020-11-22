namespace PollUp.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class PollController : ControllerBase
    {
        private static int _votes;
        private static int _yeses;

        [Route("yes")]
        [HttpPost]
        public IActionResult Yes()
        {
            _yeses++;
            _votes++;
            return Ok();
        }

        [Route("no")]
        [HttpPost]
        public IActionResult No()
        {
            _votes++;
            return Ok();
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                votes = _votes,
                yeses = _yeses,
                noes = _votes - _yeses
            });
        }

        [Route("flush")]
        [HttpPost]
        public IActionResult Flush()
        {
            (_yeses, _votes) = (0, 0);

            return Ok();
        }
    }
}