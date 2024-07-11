using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPriceListRowRepository
    {
        Task<IEnumerable<PriceListRow>> GetAllAsync();
        Task<PriceListRow> GetByIdNoTrackingAsync(int id);
        Task<PriceListRow> GetByIdAsync(int id);
        bool Add(PriceListRow row);
        bool Update(PriceListRow row);
        bool Delete(PriceListRow row);
        bool Save();
    }
}
