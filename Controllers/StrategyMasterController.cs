using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketHunter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategyMasterController : ControllerBase
    {
        private readonly IGenericCrudMethods<StrategyMaster> _strategyMaster;

        public StrategyMasterController(IGenericCrudMethods<StrategyMaster> strategyMaster)
        {
            _strategyMaster = strategyMaster;
        }

        // GET: api/StrategyMaster
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stratergyData = await _strategyMaster.GetAllAsync();
            return Ok(stratergyData);
        }

        // GET: api/StrategyMaster/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var stratergyData = await _strategyMaster.GetByIdAsync(id);
                return Ok(stratergyData);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/StrategyMaster
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StrategyMaster strategyMaster)
        {
            if (strategyMaster == null)
                return BadRequest("StrategyMaster is null.");

            await _strategyMaster.SaveAsync(strategyMaster);
            return CreatedAtAction(nameof(GetById), new { id = strategyMaster.StrategyId }, strategyMaster);
        }

        // PUT: api/StrategyMaster/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] StrategyMaster stratergyData)
        {
            if (stratergyData == null || stratergyData.StrategyId != id)
                return BadRequest("Invalid strategyMaster data.");

            try
            {
                await _strategyMaster.UpdateAsync(stratergyData);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/StrategyMaster/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _strategyMaster.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
