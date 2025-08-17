using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketHunter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeDetailController : ControllerBase
    {
        private readonly IGenericCrudMethods<TradeDetail> _tradeDetail;

        public TradeDetailController(IGenericCrudMethods<TradeDetail> tradeDetail)
        {
            _tradeDetail = tradeDetail;
        }

        // GET: api/TradeDetail
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tradeDetails = await _tradeDetail.GetAllAsync();
            return Ok(tradeDetails);
        }

        // GET: api/TradeDetail/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var tradeDetail = await _tradeDetail.GetByIdAsync(id);
                return Ok(tradeDetail);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/TradeDetail
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TradeDetail tradeDetail)
        {
            if (tradeDetail == null)
                return BadRequest("TradeDetail is null.");

            await _tradeDetail.SaveAsync(tradeDetail);
            return CreatedAtAction(nameof(GetById), new { id = tradeDetail.TradeDetailId }, tradeDetail);
        }

        // PUT: api/TradeDetail/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TradeDetail tradeDetail)
        {
            if (tradeDetail == null || tradeDetail.TradeDetailId != id)
                return BadRequest("Invalid tradeDetail data.");

            try
            {
                await _tradeDetail.UpdateAsync(tradeDetail);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/TradeDetail/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _tradeDetail.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
