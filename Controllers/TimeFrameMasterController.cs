using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketHunter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeFrameMasterController : ControllerBase
    {
        private readonly IGenericCrudMethods<TimeFrameMaster> _timeFrameMaster;

        public TimeFrameMasterController(IGenericCrudMethods<TimeFrameMaster> timeFrameMaster)
        {
            _timeFrameMaster = timeFrameMaster;
        }

        // GET: api/TimeFrameMaster
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var timeFrameMasters = await _timeFrameMaster.GetAllAsync();
            return Ok(timeFrameMasters);
        }

        // GET: api/TimeFrameMaster/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var timeFrameMaster = await _timeFrameMaster.GetByIdAsync(id);
                return Ok(timeFrameMaster);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/TimeFrameMaster
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TimeFrameMaster timeFrameMaster)
        {
            if (timeFrameMaster == null)
                return BadRequest("TimeFrameMaster is null.");

            await _timeFrameMaster.SaveAsync(timeFrameMaster);
            return CreatedAtAction(nameof(GetById), new { id = timeFrameMaster.TimeFrameId }, timeFrameMaster);
        }

        // PUT: api/TimeFrameMaster/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TimeFrameMaster timeFrameMaster)
        {
            if (timeFrameMaster == null || timeFrameMaster.TimeFrameId != id)
                return BadRequest("Invalid timeFrameMaster data.");

            try
            {
                await _timeFrameMaster.UpdateAsync(timeFrameMaster);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/TimeFrameMaster/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _timeFrameMaster.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
