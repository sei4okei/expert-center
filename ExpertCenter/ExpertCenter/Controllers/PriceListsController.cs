using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenter.Controllers
{
    public class PriceListsController : Controller
    {
        private readonly PriceListContext context;

        public PriceListsController(PriceListContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var lists = context.PriceList.ToList();
            return View(lists);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult PriceList(int id) 
        {
            var list = context.PriceList.Where(p => p.Id == id)
                .Include(p => p.PriceListRows)
                    .ThenInclude(r => r.PriceListCellValues)
                .Include(p => p.PriceListColumns)
                .FirstOrDefault();
            return View(list);
        }
    }
}
