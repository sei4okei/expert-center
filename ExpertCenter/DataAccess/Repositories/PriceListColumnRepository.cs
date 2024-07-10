using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PriceListColumnRepository : IPriceListColumnRepository
    {
        private readonly PriceListContext _context;

        public PriceListColumnRepository(PriceListContext context)
        {
            _context = context;
        }

        public bool Add(PriceListColumn priceListColumn)
        {
            _context.Add(priceListColumn);
            return Save();
        }

        public bool Delete(PriceListColumn priceListColumn)
        {
            _context.Remove(priceListColumn);
            return Save();
        }

        public async Task<IEnumerable<PriceListColumn>> GetAllAsync()
        {
            return await _context.PriceListColumn.ToListAsync();
        }

        public async Task<PriceListColumn> GetByIdAsync(int id)
        {
            return await _context.PriceListColumn
                .Where(x => x.Id == id)
                .Include(v => v.PriceListCellValues)
                .FirstOrDefaultAsync();
        }

        public async Task<PriceListColumn> GetByIdNoTrackingAsync(int id)
        {
            return await _context.PriceListColumn
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(v => v.PriceListCellValues)
                .FirstOrDefaultAsync();
        }

        public bool Save() => _context.SaveChanges() > 0 ? true : false;

        public bool Update(PriceListColumn priceListColumn)
        {
            _context.Update(priceListColumn);
            return Save();
        }
    }
}
