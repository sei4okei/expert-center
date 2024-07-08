using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<PriceListColumn> Columns { get; set; }
        public virtual ICollection<PriceListRow> Rows { get; set; }
    }
}
