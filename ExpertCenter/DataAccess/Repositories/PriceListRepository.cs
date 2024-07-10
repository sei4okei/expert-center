using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PriceListRepository : IPriceListRepository
    {
        private readonly PriceListContext _context;

        public PriceListRepository(PriceListContext context)
        {
            _context = context;
        }

        public bool Add(PriceList priceList)
        {
            _context.Add(priceList);
            return Save();
        }

        public bool Delete(PriceList priceList)
        {
            _context.Remove(priceList);
            return Save();
        }

        public async Task<IEnumerable<PriceList>> GetAllAsync()
        {
            return await _context.PriceList.ToListAsync();
        }

        public async Task<PriceList> GetByIdAsync(int id)
        {
            return await _context.PriceList
                .Where(x => x.Id == id)
                .Include(r => r.PriceListRows)
                    .ThenInclude(v => v.PriceListCellValues)
                .Include(c => c.PriceListColumns)
                .FirstOrDefaultAsync();
        }

        public async Task<PriceList> GetByIdNoTrackingAsync(int id)
        {
            return await _context.PriceList
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(r => r.PriceListRows)
                    .ThenInclude(v => v.PriceListCellValues)
                .Include(c => c.PriceListColumns)
                .FirstOrDefaultAsync();
        }

        public bool Save() => _context.SaveChanges() > 0 ? true : false;

        public bool Update(PriceList priceList)
        {
            _context.Update(priceList);
            return Save();
        }
    }
}
