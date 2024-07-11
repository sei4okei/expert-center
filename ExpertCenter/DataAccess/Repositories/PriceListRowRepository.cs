using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PriceListRowRepository : IPriceListRowRepository
    {
        private readonly PriceListContext _context;

        public PriceListRowRepository(PriceListContext context)
        {
            _context = context;
        }

        public bool Add(PriceListRow row)
        {
            _context.Add(row);
            return Save();
        }

        public bool Delete(PriceListRow row)
        {
            _context.Remove(row);
            return Save();
        }

        public async Task<IEnumerable<PriceListRow>> GetAllAsync()
        {
            return await _context.PriceListRow.ToListAsync();
        }

        public async Task<PriceListRow> GetByIdAsync(int id)
        {
            return await _context.PriceListRow
                .Include(c => c.PriceListCellValues)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PriceListRow> GetByIdNoTrackingAsync(int id)
        {
            return await _context.PriceListRow
                .AsNoTracking()
                .Include(c => c.PriceListCellValues)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save() => _context.SaveChanges() > 0 ? true : false;

        public bool Update(PriceListRow row)
        {
            _context.Update(row);
            return Save();
        }
    }
}
