

namespace MVCDemo.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBestellingRepository BestellingRepository { get; }
        IGenericRepository<Klant> KlantRepository { get; }
	    public void SaveChanges();
    }
}
