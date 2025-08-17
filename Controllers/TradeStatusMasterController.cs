using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketHunter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeStatusMasterController : ControllerBase
    {
        private readonly IGenericCrudMethods<TradeStatusMaster> _tradeStatusMaster;

        public TradeStatusMasterController(IGenericCrudMethods<TradeStatusMaster> tradeStatusMaster)
        {
            _tradeStatusMaster = tradeStatusMaster;
        }

        // GET: api/TradeStatusMaster
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tradeStatusData = await _tradeStatusMaster.GetAllAsync();
            return Ok(tradeStatusData);
        }

        // GET: api/TradeStatusMaster/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var tradeStatusData = await _tradeStatusMaster.GetByIdAsync(id);
                return Ok(tradeStatusData);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/TradeStatusMaster
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TradeStatusMaster tradeStatusMaster)
        {
            if (tradeStatusMaster == null)
                return BadRequest("TradeStatusMaster is null.");

            await _tradeStatusMaster.SaveAsync(tradeStatusMaster);
            return CreatedAtAction(nameof(GetById), new { id = tradeStatusMaster.TradeStatusId }, tradeStatusMaster);
        }

        // PUT: api/TradeStatusMaster/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TradeStatusMaster tradeStatusData)
        {
            if (tradeStatusData == null || tradeStatusData.TradeStatusId != id)
                return BadRequest("Invalid tradeStatusMaster data.");

            try
            {
                await _tradeStatusMaster.UpdateAsync(tradeStatusData);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/TradeStatusMaster/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _tradeStatusMaster.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
