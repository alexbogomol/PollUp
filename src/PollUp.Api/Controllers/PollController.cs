using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollUp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PollController : ControllerBase
    {
        private static int _votes = 0;
        private static int _yeses = 0;

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
