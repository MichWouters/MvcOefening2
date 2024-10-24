namespace MVCDemo.Data.Repository
{
    public interface IBestellingRepository: IGenericRepository<Bestelling>
    {
        Task<IEnumerable<Bestelling>> GetAllBestellingenAsync();

        Task<Bestelling?> GetBestellingAsync(int id);
    }
}
