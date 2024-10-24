﻿namespace Interimkantoor.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Omschrijving is verplicht.")]
        [StringLength(200, ErrorMessage = "Omschrijving mag maximaal 200 karakters bevatten.")]
        public string Omschrijving { get; set; } = default!;

        [Required(ErrorMessage = "Startdatum is verplicht.")]
        [DataType(DataType.Date)]
        public DateTime StartDatum { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Einddatum is verplicht.")]
        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; } = DateTime.Now.AddDays(1);

        [Required(ErrorMessage = "Locatie is verplicht.")]
        [StringLength(100, ErrorMessage = "Locatie mag maximaal 100 karakters bevatten.")]
        public string Locatie { get; set; } = default!;

        public bool IsWerkschoenen { get; set; } = false;
        public bool IsBadge { get; set; } = false;
        public bool IsKleding { get; set; } = false;

        [Range(1, 100, ErrorMessage = "Aantal plaatsen moet tussen 1 en 100 liggen.")]
        public int AantalPlaatsen { get; set; }

        public List<KlantJob>? KlantJobs { get; set; } = new List<KlantJob>();
    }
}
