

namespace MVCDemo.Controllers
{
    public class KlantController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public KlantController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<Klant>>> Index()
        {
            var klanten = await _context.KlantRepository.GetAllAsync();

            KlantListViewModel model = new KlantListViewModel()
            {
                Klanten = klanten.ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            Klant? klant = await _context.KlantRepository.GetByIdAsync(id);
            if (klant != null)
            {
                KlantDetailsViewModel vm = _mapper.Map<KlantDetailsViewModel>(klant);
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public async Task<IActionResult> Search(KlantListViewModel viewModel)
		{
			if (!string.IsNullOrEmpty(viewModel.KlantSearch))
			{
                var klanten = await _context.KlantRepository.Find(x => x.Naam.Contains(viewModel.KlantSearch) || x.Voornaam.Contains(viewModel.KlantSearch) );
				viewModel.Klanten = klanten.ToList();
			}
			else
			{
				var klanten = await _context.KlantRepository.GetAllAsync();
				viewModel.Klanten = klanten.ToList();
			}
			return View("Index", viewModel);
		}

		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KlantCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Klant klant = _mapper.Map<Klant>(viewModel);
                await _context.KlantRepository.AddAsync(klant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var klant = await _context.KlantRepository.GetByIdAsync(id);
            if (klant != null)
            {
                KlantEditViewModel viewModel = _mapper.Map<KlantEditViewModel>(klant);

                return View(viewModel);
            }
            else
            {  
                return RedirectToAction("Index"); 
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KlantEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Klant klant = _mapper.Map<Klant>(viewModel);
                    _context.KlantRepository.Update(klant);
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.KlantRepository.GetByIdAsync(id) != null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var klant = await _context.KlantRepository.GetByIdAsync(id);
            if (klant == null)
            {
                return NotFound();
            }

            KlantDeleteViewModel viewModel = _mapper.Map<KlantDeleteViewModel>(klant);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klant = await _context.KlantRepository.GetByIdAsync(id);
            if (klant != null)
            {
                _context.KlantRepository.Delete(klant);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
