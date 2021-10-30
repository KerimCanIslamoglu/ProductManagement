using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Model;
using ProductManagement.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    public class TimeController : ControllerBase
    {

        private readonly ITimeService _timeService;

        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpPut]
        [Route("api/time/increase_time")]
        public IActionResult IncreaseTime(int increment)
        {
            _timeService.IncreaseCurrentTime(increment);

            var currentTime = _timeService.GetCurrentTime();

            var time = TimeSpan.FromHours(currentTime.CurrentTime).ToString("hh':'mm");

            return Ok(new ResponseModel<string>
            {
                Success = true,
                StatusCode = 200,
                Message = $"Time is {time}",
                Response = null
            });
        }

        [HttpPut]
        [Route("api/time/reset_time")]
        public IActionResult ResetTime()
        {
            _timeService.ResetTime();

            var currentTime = _timeService.GetCurrentTime();

            var time = TimeSpan.FromHours(currentTime.CurrentTime).ToString("hh':'mm");

            return Ok(new ResponseModel<string>
            {
                Success = true,
                StatusCode = 200,
                Message = $"Time is {time}",
                Response = null
            });
        }
    }
}
