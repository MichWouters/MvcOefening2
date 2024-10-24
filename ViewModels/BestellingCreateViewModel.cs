using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCDemo.ViewModels
{
    public class BestellingCreateViewModel
    {
        public int Id { get; set; }

        public List<SelectListItem> Klanten { get; set; } = new  List<SelectListItem>();
        public List<OrderLijnCreateViewModel> OrderLijnen { get; set; } = new List<OrderLijnCreateViewModel>();
        public List<SelectListItem> Producten { get; set; } = new List<SelectListItem>();



    }
}
