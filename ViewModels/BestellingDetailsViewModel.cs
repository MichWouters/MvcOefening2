
namespace MVCDemo.ViewModels
{
    public class BestellingDetailsViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<OrderlijnViewModel> Orderlijnen { get; set; }
    }
}
