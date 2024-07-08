using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    internal class PriceListRow
    {
        public int Id { get; set; }
        public int PriceListId { get; set; }
        public virtual PriceList PriceList { get; set; }

        public virtual ICollection<PriceListCellValue> CellValues { get; set; }
    }
}
