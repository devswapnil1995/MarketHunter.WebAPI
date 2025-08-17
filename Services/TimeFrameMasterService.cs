using MarketHunter.WebAPI.Data;
using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketHunter.WebAPI.Services
{
    public class TimeFrameMasterService : IGenericCrudMethods<TimeFrameMaster>
    {
        private readonly AppDBContext _dbContext;
        public TimeFrameMasterService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TimeFrameMaster>> GetAllAsync()
        {
            return await _dbContext.TimeFrameMaster.ToListAsync();
        }

        public async Task<TimeFrameMaster> GetByIdAsync(Guid entityId)
        {
            var timeFrameData = await _dbContext.TimeFrameMaster
                   .Where(x => x.TimeFrameId == entityId)
                   .FirstOrDefaultAsync();

            if (timeFrameData == null)
                throw new KeyNotFoundException("TimeFrameData not found.");

            return timeFrameData;
        }

        public async Task SaveAsync(TimeFrameMaster TimeFrameMaster)
        {
            TimeFrameMaster.TimeFrameId = Guid.NewGuid();
            await _dbContext.TimeFrameMaster.AddAsync(TimeFrameMaster);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TimeFrameMaster TimeFrameMaster)
        {
            var existing = await _dbContext.TimeFrameMaster.FirstOrDefaultAsync(i => i.TimeFrameId == TimeFrameMaster.TimeFrameId);

            if (existing == null)
                throw new KeyNotFoundException("TimeFrameData not found.");

            existing = TimeFrameMaster;
            existing.DateModified = DateTime.UtcNow;

            _dbContext.TimeFrameMaster.Update(existing);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid TimeFrameId)
        {
            var existing = await _dbContext.TimeFrameMaster.FirstOrDefaultAsync(i => i.TimeFrameId == TimeFrameId);

            if (existing == null)
                throw new KeyNotFoundException("TimeFrameData not found.");

            _dbContext.TimeFrameMaster.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
