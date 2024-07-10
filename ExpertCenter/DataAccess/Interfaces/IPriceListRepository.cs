using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IPriceListRepository
    {
        Task<IEnumerable<PriceList>> GetAllAsync();
        Task<PriceList> GetByIdNoTrackingAsync(int id);
        Task<PriceList> GetByIdAsync(int id);
        bool Add(PriceList priceList);
        bool Update(PriceList priceList);
        bool Delete(PriceList priceList);
        bool Save();
    }
}
