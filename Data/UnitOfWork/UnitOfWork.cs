

namespace MVCDemo.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MVCDemoContext _context;

        private IBestellingRepository bestellingRepository;
        private IGenericRepository<Klant> klantRepository;

        public UnitOfWork(MVCDemoContext context)
        {
            _context = context;
        }

        public IBestellingRepository BestellingRepository
        {
            get
            {
                if (this.bestellingRepository == null)
                        this.bestellingRepository = new BestellingRepository(_context);
                return bestellingRepository;
            }
        }

        public IGenericRepository<Klant> KlantRepository
        {
            get
            {
                if (this.klantRepository == null)
				this.klantRepository = new GenericRepository<Klant>(_context);
			return klantRepository;
		    }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
