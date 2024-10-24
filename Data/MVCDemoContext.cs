
namespace MVCDemo.Data
{
    public class MVCDemoContext: DbContext
    {
        public MVCDemoContext(DbContextOptions<MVCDemoContext> options) : base(options) { }

        public DbSet<Product> Producten {  get; set; }
        public DbSet<Klant> Klanten {  get; set; }
        public DbSet<Bestelling> Bestellingen {  get; set; }
        public DbSet<Orderlijn> Orderlijnen {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Klant>().ToTable("Klant");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling");
            modelBuilder.Entity<Orderlijn>().ToTable("Orderlijn");
            modelBuilder.Entity<Product>().ToTable("Product").Property(p=>p.Prijs).HasColumnType("decimal(18,2)");

            // One to many 
            modelBuilder.Entity<Bestelling>()
                .HasOne(p => p.Klant)
                .WithMany(x => x.Bestellingen)
                .HasForeignKey(y => y.KlantId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many to many 
            modelBuilder.Entity<Orderlijn>()
                .HasOne(p => p.Bestelling)
                .WithMany(x => x.Orderlijnen)
                .HasForeignKey(y => y.BestellingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orderlijn>()
                .HasOne(p => p.Product)
                .WithMany(x => x.Orderlijnen)
                .HasForeignKey(y => y.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
