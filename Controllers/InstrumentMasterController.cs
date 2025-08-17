using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketHunter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentMasterController : ControllerBase
    {
        private readonly IGenericCrudMethods<InstrumentMaster> _instrumentService;

        public InstrumentMasterController(IGenericCrudMethods<InstrumentMaster> instrumentService)
        {
            _instrumentService = instrumentService;
        }

        // GET: api/InstrumentMaster
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var instruments = await _instrumentService.GetAllAsync();
            return Ok(instruments);
        }

        // GET: api/InstrumentMaster/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var instrument = await _instrumentService.GetByIdAsync(id);
                return Ok(instrument);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/InstrumentMaster
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InstrumentMaster instrument)
        {
            if (instrument == null)
                return BadRequest("Instrument is null.");

            await _instrumentService.SaveAsync(instrument);
            return CreatedAtAction(nameof(GetById), new { id = instrument.InstrumentId }, instrument);
        }

        // PUT: api/InstrumentMaster/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] InstrumentMaster instrument)
        {
            if (instrument == null || instrument.InstrumentId != id)
                return BadRequest("Invalid instrument data.");

            try
            {
                await _instrumentService.UpdateAsync(instrument);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/InstrumentMaster/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _instrumentService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
