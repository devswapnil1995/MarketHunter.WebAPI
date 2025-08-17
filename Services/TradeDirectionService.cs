using MarketHunter.WebAPI.Data;
using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketHunter.WebAPI.Services
{
    public class TradeDirectionService : IGenericCrudMethods<TradeDirection>
    {
        private readonly AppDBContext _dbContext;
        public TradeDirectionService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TradeDirection>> GetAllAsync()
        {
            return await _dbContext.TradeDirection.ToListAsync();
        }

        public async Task<TradeDirection> GetByIdAsync(Guid entityId)
        {
            var tradeDirectionData = await _dbContext.TradeDirection
                   .Where(x => x.TradeDirectionId == entityId)
                   .FirstOrDefaultAsync();

            if (tradeDirectionData == null)
                throw new KeyNotFoundException("TradeDirection not found.");

            return tradeDirectionData;
        }

        public async Task SaveAsync(TradeDirection TradeDirection)
        {
            TradeDirection.TradeDirectionId = Guid.NewGuid();
            await _dbContext.TradeDirection.AddAsync(TradeDirection);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TradeDirection TradeDirection)
        {
            var existing = await _dbContext.TradeDirection.FirstOrDefaultAsync(i => i.TradeDirectionId == TradeDirection.TradeDirectionId);

            if (existing == null)
                throw new KeyNotFoundException("TradeDirection not found.");

            existing = TradeDirection;
            existing.DateModified = DateTime.UtcNow;

            _dbContext.TradeDirection.Update(existing);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid TimeFrameId)
        {
            var existing = await _dbContext.TradeDirection.FirstOrDefaultAsync(i => i.TradeDirectionId == TimeFrameId);

            if (existing == null)
                throw new KeyNotFoundException("TradeDirection not found.");

            _dbContext.TradeDirection.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
