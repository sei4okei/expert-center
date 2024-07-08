using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class PriceList
{
    public int Id { get; set; }

    public string Name { get; set; }/* = null!;*/

    public DateOnly CreatedDate { get; set; }

    public virtual ICollection<PriceListColumn> PriceListColumns { get; set; }/* = new List<PriceListColumn>();*/

    public virtual ICollection<PriceListRow> PriceListRows { get; set; }/* = new List<PriceListRow>();*/
}
