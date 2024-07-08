using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class PriceListColumn
{
    public int Id { get; set; }

    public string Name { get; set; }/* = null!;*/

    public string DataType { get; set; }/* = null!;*/

    public int PriceListId { get; set; }

    public virtual PriceList PriceList { get; set; }/* = null!;*/

    public virtual ICollection<PriceListCellValue> PriceListCellValues { get; set; }/* = new List<PriceListCellValue>();*/
}
