namespace DataAccess.Models
{
    public class AddRowViewModel
    {
        public int PriceListId { get; set; }
        public List<ColumnViewModel> Columns { get; set; } = new List<ColumnViewModel>();
    }
}
