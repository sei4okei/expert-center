using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;

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
        //[ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] CreatePriceListViewModel model)
        {
            if (ModelState.IsValid!) return RedirectToAction("Create");

            var result = _priceListService.Create(model);

            if (result == false) return RedirectToAction("Create");

            return RedirectToAction("Index");
        }
    }
}
