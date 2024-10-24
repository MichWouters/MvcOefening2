

namespace MVCDemo.ViewModels
{
    public class BestellingEditViewModel
    {
        public int BestellingID { get; set; }
        public string KlantNaam { get; set; } = default!;
        public int KlantID { get; set; }
        public List<OrderLijnEditViewModel> Orderlijnen { get; set; } = default!;
    }
}
