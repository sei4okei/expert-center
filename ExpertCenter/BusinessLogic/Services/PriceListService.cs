using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PriceListService : IPriceListService
    {
        private readonly IPriceListRepository _priceListRepository;
        private readonly IPriceListColumnRepository _priceListColumnRepository;

        public PriceListService(IPriceListRepository priceListRepository, IPriceListColumnRepository priceListColumnRepository)
        {
            _priceListRepository = priceListRepository;
            _priceListColumnRepository = priceListColumnRepository;
        }

        public async Task<CreatePriceListViewModel> Create()
        {
            var existingColumns = await _priceListColumnRepository.GetAllAsync();

            return new CreatePriceListViewModel()
            {
                Columns = new List<ColumnViewModel>(),
                ExistingColumns = existingColumns.Select(x => new ColumnViewModel
                {
                    Name = x.Name,
                    DataType = x.DataType,
                    IsSelected = false
                }).ToList()
            };
        }

        public bool Create(CreatePriceListViewModel viewModel)
        {
            var priceList = new PriceList
            {
                Name = viewModel.Name,
                CreatedDate = DateTime.Now,
                PriceListColumns = new List<PriceListColumn>(),
                PriceListRows = new List<PriceListRow>()
            };

            foreach (var existingColumn in viewModel.ExistingColumns.Where(c => c.IsSelected))
            {
                priceList.PriceListColumns.Add(new PriceListColumn
                {
                    Name = existingColumn.Name,
                    DataType = existingColumn.DataType
                });
            }

            foreach (var newColumn in viewModel.Columns)
            {
                priceList.PriceListColumns.Add(new PriceListColumn
                {
                    Name = newColumn.Name,
                    DataType = newColumn.DataType
                });
            }

            return _priceListRepository.Add(priceList);
        }
    }
}
