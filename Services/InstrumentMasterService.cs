using MarketHunter.WebAPI.Data;
using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketHunter.WebAPI.Services
{
    public class InstrumentMasterService : IGenericCrudMethods<InstrumentMaster>
    {
        private readonly AppDBContext _dbContext;
        public InstrumentMasterService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<InstrumentMaster>> GetAllAsync()
        {
            return await _dbContext.InstrumentMaster.ToListAsync();
        }

        public async Task<InstrumentMaster> GetByIdAsync(Guid entityId)
        {
            var instrument = await _dbContext.InstrumentMaster
                   .Where(x => x.InstrumentId == entityId)
                   .FirstOrDefaultAsync();

            if (instrument == null)
                throw new KeyNotFoundException("Instrument not found.");

            return instrument;
        }

        public async Task SaveAsync(InstrumentMaster instrumentMaster)
        {
            instrumentMaster.InstrumentId = Guid.NewGuid();
            await _dbContext.InstrumentMaster.AddAsync(instrumentMaster);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(InstrumentMaster instrumentMaster)
        {
            var existing = await _dbContext.InstrumentMaster.FirstOrDefaultAsync(i => i.InstrumentId == instrumentMaster.InstrumentId);

            if (existing == null)
                throw new KeyNotFoundException("Instrument not found.");

            existing.InstrumentName = instrumentMaster.InstrumentName;
            existing.InstrumentKey = instrumentMaster.InstrumentKey;
            existing.InstrumentCode = instrumentMaster.InstrumentCode;
            existing.DateModified = DateTime.UtcNow;

            _dbContext.InstrumentMaster.Update(existing);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid instrumentId)
        {
            var existing = await _dbContext.InstrumentMaster.FirstOrDefaultAsync(i => i.InstrumentId == instrumentId);

            if (existing == null)
                throw new KeyNotFoundException("Instrument not found.");

            _dbContext.InstrumentMaster.Remove(existing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
