using MarketHunter.WebAPI.Data;
using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketHunter.WebAPI.Services
{
    public class TradeStatusMasterService : IGenericCrudMethods<TradeStatusMaster>
    {
        private readonly AppDBContext _dbContext;
        public TradeStatusMasterService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TradeStatusMaster>> GetAllAsync()
        {
            return await _dbContext.TradeStatusMaster.ToListAsync();
        }

        public async Task<TradeStatusMaster> GetByIdAsync(Guid entityId)
        {
            var tradeStatusMasterData = await _dbContext.TradeStatusMaster
                   .Where(x => x.TradeStatusId == entityId)
                   .FirstOrDefaultAsync();

            if (tradeStatusMasterData == null)
                throw new KeyNotFoundException("TradeStatusMaster not found.");

            return tradeStatusMasterData;
        }

        public async Task SaveAsync(TradeStatusMaster TradeStatusMaster)
        {
            TradeStatusMaster.TradeStatusId = Guid.NewGuid();
            await _dbContext.TradeStatusMaster.AddAsync(TradeStatusMaster);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TradeStatusMaster TradeStatusMaster)
        {
            var existing = await _dbContext.TradeStatusMaster.FirstOrDefaultAsync(i => i.TradeStatusId == TradeStatusMaster.TradeStatusId);

            if (existing == null)
                throw new KeyNotFoundException("TradeStatusMaster not found.");

            existing = TradeStatusMaster;
            existing.DateModified = DateTime.UtcNow;

            _dbContext.TradeStatusMaster.Update(existing);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid TimeFrameId)
        {
            var existing = await _dbContext.TradeStatusMaster.FirstOrDefaultAsync(i => i.TradeStatusId == TimeFrameId);

            if (existing == null)
                throw new KeyNotFoundException("TradeStatusMaster not found.");

            _dbContext.TradeStatusMaster.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
