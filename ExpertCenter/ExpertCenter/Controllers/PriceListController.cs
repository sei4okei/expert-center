using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DataAccess.Models;

namespace ExpertCenter.Controllers
{
    public class PriceListController : Controller
    {
        private readonly IPriceListRepository _priceListRepository;
        private readonly IPriceListService _priceListService;

        public PriceListController(IPriceListRepository priceListRepository, IPriceListService priceListService)
        {
            _priceListRepository = priceListRepository;
            _priceListService = priceListService;
        }

        public async Task<IActionResult> Index()
        {
            var lists = await _priceListRepository.GetAllAsync();
            return View(lists);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public async Task<IActionResult> PriceList(int id) 
        {
            var list = await _priceListRepository.GetByIdAsync(id);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _priceListService.Create();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm]CreatePriceListViewModel model, string addColumn, string removeColumn)
        {
            if (!string.IsNullOrEmpty(addColumn))
            {
                model.Columns.Add(new BusinessLogic.Models.ColumnViewModel());
                return View(model);
            }

            if (!string.IsNullOrEmpty(removeColumn))
            {
                int idToRemove;
                if (int.TryParse(removeColumn, out idToRemove))
                {
                    var columnToRemove = model.Columns.FirstOrDefault(c => c.Id == idToRemove);
                    if (columnToRemove != null)
                    {
                        model.Columns.Remove(columnToRemove);
                    }
                }
                return View(model);
            }

            if (ModelState.IsValid) return RedirectToAction("Create");

            var result = _priceListService.Create(model);

            if (result == false) return RedirectToAction("Create");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddRow(int id)
        {
            var model = await _priceListRepository.GetAddRowViewModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRow(AddRowViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _priceListRepository.AddRowAsync(model);
                return RedirectToAction("PriceList", new { id = model.PriceListId });
            }
            return View(model);
        }

    }
}
