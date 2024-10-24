

namespace MVCDemo.Data.Repository
{
    public class BestellingRepository : GenericRepository<Bestelling>, IBestellingRepository
    {
        public BestellingRepository(MVCDemoContext context) : base(context) { }

        public async Task<IEnumerable<Bestelling>> GetAllBestellingenAsync()
        {
            return await _context.Bestellingen.Include(x => x.Klant).ToListAsync();
        }

        public async Task<Bestelling?> GetBestellingAsync(int id)
        {
            return await _context.Bestellingen.Include(x => x.Klant).Include(x=>x.Orderlijnen).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
