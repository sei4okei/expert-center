using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IPriceListColumnRepository
    {
        Task<IEnumerable<PriceListColumn>> GetAllAsync();
        Task<PriceListColumn> GetByIdNoTrackingAsync(int id);
        Task<PriceListColumn> GetByIdAsync(int id);
        bool Add(PriceListColumn priceList);
        bool Update(PriceListColumn priceList);
        bool Delete(PriceListColumn priceList);
        bool Save();
    }
}
