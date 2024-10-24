

namespace MVCDemo.ViewModels
{
    public class KlantCreateViewModel
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [DataType(DataType.Date), Display(Name = "Datum Aangemaakt")]

        public DateTime AangemaaktDatum { get; set; }
    }
}
