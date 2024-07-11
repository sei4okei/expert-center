using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class PriceListCellValue
{
    public int Id { get; set; }

    public int RowId { get; set; }

    public int ColumnId { get; set; }

    public string Value { get; set; }

    public virtual PriceListColumn Column { get; set; }

    public virtual PriceListRow Row { get; set; }
}
