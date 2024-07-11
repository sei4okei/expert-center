using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class PriceListRow
{
    public int Id { get; set; }

    public int PriceListId { get; set; }

    public virtual PriceList PriceList { get; set; }

    public virtual ICollection<PriceListCellValue> PriceListCellValues { get; set; }
}
