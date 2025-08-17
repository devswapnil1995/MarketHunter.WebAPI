using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketHunter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeMasterController : ControllerBase
    {
        private readonly IGenericCrudMethods<TradeMaster> _tradeMaster;

        public TradeMasterController(IGenericCrudMethods<TradeMaster> tradeMaster)
        {
            _tradeMaster = tradeMaster;
        }

        // GET: api/TradeMaster
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tradeMasters = await _tradeMaster.GetAllAsync();
            return Ok(tradeMasters);
        }

        // GET: api/TradeMaster/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var tradeMaster = await _tradeMaster.GetByIdAsync(id);
                return Ok(tradeMaster);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/TradeMaster
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TradeMaster tradeMaster)
        {
            if (tradeMaster == null)
                return BadRequest("TradeMaster is null.");

            await _tradeMaster.SaveAsync(tradeMaster);
            return CreatedAtAction(nameof(GetById), new { id = tradeMaster.TradeMasterId }, tradeMaster);
        }

        // PUT: api/TradeMaster/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TradeMaster tradeMaster)
        {
            if (tradeMaster == null || tradeMaster.TradeMasterId != id)
                return BadRequest("Invalid tradeMaster data.");

            try
            {
                await _tradeMaster.UpdateAsync(tradeMaster);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/TradeMaster/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _tradeMaster.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
