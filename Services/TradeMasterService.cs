using MarketHunter.WebAPI.Data;
using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketHunter.WebAPI.Services
{
    public class TradeMasterService : IGenericCrudMethods<TradeMaster>
    {
        private readonly AppDBContext _dbContext;
        public TradeMasterService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TradeMaster>> GetAllAsync()
        {
            return await _dbContext.TradeMaster.ToListAsync();
        }

        public async Task<TradeMaster> GetByIdAsync(Guid entityId)
        {
            var tradeMasterData = await _dbContext.TradeMaster
                   .Where(x => x.TradeMasterId == entityId)
                   .FirstOrDefaultAsync();

            if (tradeMasterData == null)
                throw new KeyNotFoundException("TradeMaster not found.");

            return tradeMasterData;
        }

        public async Task SaveAsync(TradeMaster TradeMaster)
        {
            TradeMaster.TradeMasterId = Guid.NewGuid();
            await _dbContext.TradeMaster.AddAsync(TradeMaster);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TradeMaster TradeMaster)
        {
            var existing = await _dbContext.TradeMaster.FirstOrDefaultAsync(i => i.TradeMasterId == TradeMaster.TradeMasterId);

            if (existing == null)
                throw new KeyNotFoundException("TradeMaster not found.");

            existing = TradeMaster;
            existing.DateModified = DateTime.UtcNow;

            _dbContext.TradeMaster.Update(existing);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid TimeFrameId)
        {
            var existing = await _dbContext.TradeMaster.FirstOrDefaultAsync(i => i.TradeMasterId == TimeFrameId);

            if (existing == null)
                throw new KeyNotFoundException("TradeMaster not found.");

            _dbContext.TradeMaster.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
