using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    internal class PriceListCellValue
    {
        public int Id { get; set; }
        public int RowId { get; set; }
        public virtual PriceListRow Row { get; set; }

        public int ColumnId { get; set; }
        public virtual PriceListColumn Column { get; set; }

        public string Value { get; set; }
    }
}
