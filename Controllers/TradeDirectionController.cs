using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketHunter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeDirectionController : ControllerBase
    {
        private readonly IGenericCrudMethods<TradeDirection> _tradeDirection;

        public TradeDirectionController(IGenericCrudMethods<TradeDirection> tradeDirection)
        {
            _tradeDirection = tradeDirection;
        }

        // GET: api/TradeDirection
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tradeDirectionData = await _tradeDirection.GetAllAsync();
            return Ok(tradeDirectionData);
        }

        // GET: api/TradeDirection/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var tradeDirectionData = await _tradeDirection.GetByIdAsync(id);
                return Ok(tradeDirectionData);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/TradeDirection
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TradeDirection tradeDirection)
        {
            if (tradeDirection == null)
                return BadRequest("TradeDirection is null.");

            await _tradeDirection.SaveAsync(tradeDirection);
            return CreatedAtAction(nameof(GetById), new { id = tradeDirection.TradeDirectionId }, tradeDirection);
        }

        // PUT: api/TradeDirection/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TradeDirection tradeDirectionData)
        {
            if (tradeDirectionData == null || tradeDirectionData.TradeDirectionId != id)
                return BadRequest("Invalid tradeDirection data.");

            try
            {
                await _tradeDirection.UpdateAsync(tradeDirectionData);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/TradeDirection/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _tradeDirection.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
