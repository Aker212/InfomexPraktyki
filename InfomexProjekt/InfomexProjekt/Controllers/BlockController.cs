using InfomexProjekt.Interfaces;
using Microsoft.AspNetCore.Mvc;


    [ApiController]
    [Route("api/[controller]")]
    public class TimeBlockController : ControllerBase
    {
        private readonly ITimeBlock _timeBlockService;

        public TimeBlockController(ITimeBlock timeBlockService)
        {
            _timeBlockService = timeBlockService;
        }

        [HttpGet]
        public ActionResult<DateTime[]> GetTimeBlocks(DateTime startDate, DateTime endDate, int numberOfBlocks)
        {
            DateTime[] timeBlocks = _timeBlockService.SearchForBroadbandTimeBlocks(startDate, endDate, numberOfBlocks);

            return Ok(timeBlocks);
        }
    }




