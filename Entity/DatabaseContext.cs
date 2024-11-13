using EntityFramework.Configs;
using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext(string _connectionString) : DbContext {
    public DbSet<Auteur> auteurs { get; set; }
    public DbSet<Bibliotheque> bibliotheques { get; set; }
    public DbSet<Pret> prets { get; set; }
    public DbSet<Livre> livres { get; set; }
    public DbSet<Utilisateur> utilisateurs { get; set; }
    public DbSet<Vente> ventes { get; set; }

    public DbSet<PretLivre> pretsLivres { get; set; }
    public DbSet<LivreAuteur> livreAuteurs { get; set; }
    public DbSet<StockLivre> stockLivres { get; set; }
    public DbSet<VenteLivre> venteLivres { get; set; }
    public DbSet<Genre> genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
