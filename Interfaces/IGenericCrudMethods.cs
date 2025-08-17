using MarketHunter.WebAPI.Models;

namespace MarketHunter.WebAPI.Interfaces
{
    public interface IGenericCrudMethods<T>
    {
        Task<T> GetByIdAsync(Guid entityId);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync(T instrumentMaster);
        Task UpdateAsync(T instrumentMaster);
        Task DeleteAsync(Guid instrumentId);
    }
}
