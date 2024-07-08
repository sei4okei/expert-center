using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public partial class PriceListContext : DbContext
{
    public virtual DbSet<PriceList> PriceList { get; set; }

    public virtual DbSet<PriceListCellValue> PriceListCellValue { get; set; }

    public virtual DbSet<PriceListColumn> PriceListColumn { get; set; }

    public virtual DbSet<PriceListRow> PriceListRow { get; set; }

    public PriceListContext(DbContextOptions<PriceListContext> options)
        : base(options)
    {
    }
}
