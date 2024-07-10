using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class CreatePriceListViewModel
    {
        public string Name { get; set; }
        public List<ColumnViewModel> Columns { get; set; }
        public List<ColumnViewModel> ExistingColumns { get; set; }
    }
}
