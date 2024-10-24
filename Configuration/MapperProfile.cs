namespace MVCDemo.Configuration
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Klant, KlantDetailsViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => $"{src.Voornaam} {src.Naam}"));

            CreateMap<KlantCreateViewModel, Klant>();

            CreateMap<KlantEditViewModel, Klant>();

            CreateMap<Klant, KlantEditViewModel>();

            CreateMap<Klant, KlantDeleteViewModel>();

            CreateMap<Bestelling, BestellingViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => $"{src.Klant.Voornaam} {src.Klant.Naam}"));

            CreateMap<Bestelling, BestellingDetailsViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => $"{src.Klant.Voornaam} {src.Klant.Naam}"))
                .ForMember(dest => dest.Orderlijnen, opt => opt.MapFrom(src => src.Orderlijnen));

            CreateMap<Orderlijn, OrderlijnViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => src.Product.Naam))
                .ForMember(dest => dest.Prijs, opt => opt.MapFrom(src => src.Product.Prijs));
        }
    }
}
