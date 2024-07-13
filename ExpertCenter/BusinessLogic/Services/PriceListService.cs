using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly IPriceListRowRepository _priceListRowRepository;

        public PriceListService(IPriceListRepository priceListRepository, IPriceListColumnRepository priceListColumnRepository, IPriceListRowRepository priceListRowRepository)
        {
            _priceListRepository = priceListRepository;
            _priceListColumnRepository = priceListColumnRepository;
            _priceListRowRepository = priceListRowRepository;
        }

        public bool AddRow(AddRowViewModel viewModel)
        {
            var newRow = new PriceListRow
            {
                PriceListId = viewModel.PriceListId,
                PriceListCellValues = viewModel.Columns.Select(col => new PriceListCellValue
                {
                    ColumnId = col.Id,
                    Value = col.Value
                }).ToList()
            };

            return _priceListRowRepository.Add(newRow);
        }

        public async Task<CreatePriceListViewModel> Create()
        {
            return new CreatePriceListViewModel()
            {
                Columns = new List<ColumnViewModel>()
                {
                    new ColumnViewModel
                    {
                        Name = "Название товара",
                        DataType = "Однострочный текст",
                    },
                    new ColumnViewModel
                    {
                        Name = "Код товара",
                        DataType = "Число",
                    }
                }
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

        public async Task<bool> DeleteRowAsync(int rowId)
        {
            var row = await _priceListRowRepository.GetByIdAsync(rowId);

            return _priceListRowRepository.Delete(row);
        }

        public async Task<AddRowViewModel> GetAddRowViewModelAsync(int priceListId)
        {
            var priceList = await _priceListRepository.GetByIdAsync(priceListId);
            var model = new AddRowViewModel
            {
                PriceListId = priceListId,
                Columns = priceList.PriceListColumns.Select(col => new ColumnViewModel
                {
                    Id = col.Id,
                    Name = col.Name,
                    DataType = col.DataType
                }).ToList()
            };
            return model;
        }

        public async Task<List<PriceList>> GetAllPriceListsAsync()
        {
            return await _priceListRepository.GetAllAsync();
        }

        public async Task<PriceList> GetPriceListByIdAsync(int priceListId)
        {
            return await _priceListRepository.GetByIdAsync(priceListId);
        }
    }
}
