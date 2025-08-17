using MarketHunter.WebAPI.Data;
using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketHunter.WebAPI.Services
{
    public class StrategyMasterService : IGenericCrudMethods<StrategyMaster>
    {
        private readonly AppDBContext _dbContext;
        public StrategyMasterService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<StrategyMaster>> GetAllAsync()
        {
            return await _dbContext.StrategyMaster.ToListAsync();
        }

        public async Task<StrategyMaster> GetByIdAsync(Guid entityId)
        {
            var strategyMasterData = await _dbContext.StrategyMaster
                   .Where(x => x.StrategyId == entityId)
                   .FirstOrDefaultAsync();

            if (strategyMasterData == null)
                throw new KeyNotFoundException("StrategyMaster not found.");

            return strategyMasterData;
        }

        public async Task SaveAsync(StrategyMaster StrategyMaster)
        {
            StrategyMaster.StrategyId = Guid.NewGuid();
            await _dbContext.StrategyMaster.AddAsync(StrategyMaster);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StrategyMaster StrategyMaster)
        {
            var existing = await _dbContext.StrategyMaster.FirstOrDefaultAsync(i => i.StrategyId == StrategyMaster.StrategyId);

            if (existing == null)
                throw new KeyNotFoundException("StrategyMaster not found.");

            existing = StrategyMaster;
            existing.DateModified = DateTime.UtcNow;

            _dbContext.StrategyMaster.Update(existing);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid TimeFrameId)
        {
            var existing = await _dbContext.StrategyMaster.FirstOrDefaultAsync(i => i.StrategyId == TimeFrameId);

            if (existing == null)
                throw new KeyNotFoundException("StrategyMaster not found.");

            _dbContext.StrategyMaster.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
