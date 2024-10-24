

namespace MVCDemo.ViewModels
{
	public class KlantDetailsViewModel
	{
        [Required]
        public string Naam { get; set; }

        [DataType(DataType.Date), Display(Name = "Datum Aangemaakt")]

        public DateTime AangemaaktDatum { get; set; }
    }
}
