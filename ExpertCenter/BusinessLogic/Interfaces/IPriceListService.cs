using BusinessLogic.Models;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPriceListService
    {
        Task<CreatePriceListViewModel> Create();
        bool Create(CreatePriceListViewModel viewModel);
        Task<bool> DeleteRowAsync(int rowId);
        bool AddRow(AddRowViewModel viewModel);
        Task<AddRowViewModel> GetAddRowViewModelAsync(int priceListId);
        Task<List<PriceList>> GetAllPriceListsAsync();
        Task<PriceList> GetPriceListByIdAsync(int priceListId);
    }
}
