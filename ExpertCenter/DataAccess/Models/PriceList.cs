using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class PriceList
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<PriceListColumn> PriceListColumns { get; set; }

    public virtual ICollection<PriceListRow> PriceListRows { get; set; }
}
