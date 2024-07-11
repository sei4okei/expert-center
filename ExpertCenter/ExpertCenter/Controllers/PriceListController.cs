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
        private readonly IPriceListService _priceListService;

        public PriceListController(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }

        public async Task<IActionResult> Index()
        {
            var lists = await _priceListService.GetAllPriceListsAsync();
            return View(lists);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public async Task<IActionResult> PriceList(int id) 
        {
            var list = await _priceListService.GetPriceListByIdAsync(id);
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
            if (ModelState.IsValid) return RedirectToAction("Create");

            var result = _priceListService.Create(model);

            if (result == false) return RedirectToAction("Create");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddRow(int priceListId)
        {
            var model = await _priceListService.GetAddRowViewModelAsync(priceListId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRow(AddRowViewModel model)
        {
            if (ModelState.IsValid!) return View(model);

            var result = _priceListService.AddRow(model);

            if (result != true) return View(model);

            return RedirectToAction("PriceList", new { id = model.PriceListId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRow(int rowId, int priceListId)
        {
            var result = await _priceListService.DeleteRowAsync(rowId);

            return RedirectToAction("PriceList", new { id = priceListId });
        }

    }
}
