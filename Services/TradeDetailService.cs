using MarketHunter.WebAPI.Data;
using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketHunter.WebAPI.Services
{
    public class TradeDetailService : IGenericCrudMethods<TradeDetail>
    {
        private readonly AppDBContext _dbContext;
        public TradeDetailService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TradeDetail>> GetAllAsync()
        {
            return await _dbContext.TradeDetail.ToListAsync();
        }

        public async Task<TradeDetail> GetByIdAsync(Guid entityId)
        {
            var tradeDetailData = await _dbContext.TradeDetail
                   .Where(x => x.TradeDetailId == entityId)
                   .FirstOrDefaultAsync();

            if (tradeDetailData == null)
                throw new KeyNotFoundException("TradeDetail not found.");

            return tradeDetailData;
        }

        public async Task SaveAsync(TradeDetail TradeDetail)
        {
            TradeDetail.TradeDetailId = Guid.NewGuid();
            await _dbContext.TradeDetail.AddAsync(TradeDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TradeDetail TradeDetail)
        {
            var existing = await _dbContext.TradeDetail.FirstOrDefaultAsync(i => i.TradeDetailId == TradeDetail.TradeDetailId);

            if (existing == null)
                throw new KeyNotFoundException("TradeDetail not found.");

            existing = TradeDetail;
            existing.DateModified = DateTime.UtcNow;

            _dbContext.TradeDetail.Update(existing);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid TradeDetailId)
        {
            var existing = await _dbContext.TradeDetail.FirstOrDefaultAsync(i => i.TradeDetailId == TradeDetailId);

            if (existing == null)
                throw new KeyNotFoundException("TradeDetail not found.");

            _dbContext.TradeDetail.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
