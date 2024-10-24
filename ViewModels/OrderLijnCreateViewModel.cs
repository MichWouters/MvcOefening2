



namespace MVCDemo.ViewModels
{
    public class OrderLijnCreateViewModel
    {
            public int ProductID { get; set; }
            public int Aantal { get; set; }

        public List<SelectListItem> Producten { get; set; } = new List<SelectListItem>();
    }
 
}
