

namespace MVCDemo.Controllers
{

    public class BestellingController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public BestellingController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<ActionResult> Index()
        {
            var bestellingen = await _context.BestellingRepository.GetAllBestellingenAsync();
            
            BestellingListViewModel model = new BestellingListViewModel();

            model.Bestellingen = _mapper.Map<List<BestellingViewModel>>(bestellingen);

            return View(model);
        }
        public async Task<ActionResult<Bestelling>> GetBestelling(int id)
        {
            Bestelling bestelling = await _context.BestellingRepository.GetBestellingAsync(id);

            if (bestelling == null) return NotFound();

            BestellingDetailsViewModel viewModel = _mapper.Map<BestellingDetailsViewModel>(bestelling);

            return View(viewModel);
        }

    }
    
}
