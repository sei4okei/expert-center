using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    internal class PriceListColumn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }

        public int PriceListId { get; set; }
        public virtual PriceList PriceList { get; set; }
    }
}
