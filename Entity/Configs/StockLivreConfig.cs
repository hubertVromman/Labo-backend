using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace EntityFramework.Configs {
    internal class StockLivreConfig : IEntityTypeConfiguration<StockLivre> {
        public void Configure(EntityTypeBuilder<StockLivre> builder) {
            builder.HasKey(sl => new { sl.LivreId, sl.BibliothequeId });

            builder
                .HasOne(sl => sl.Livre)
                .WithMany(l => l.StockLivre)
                .HasForeignKey(fk => fk.LivreId)
                .HasConstraintName("FK_StockLivre_Livre");

            builder
                .HasOne(sl => sl.Bibliotheque)
                .WithMany(l => l.StockLivre)
                .HasForeignKey(fk => fk.BibliothequeId)
                .HasConstraintName("FK_StockLivre_Bibliotheque");

            builder.HasData(
                new StockLivre() {
                    LivreId = -1,
                    BibliothequeId = -1,
                    StockAchat = 10,
                    StockLocation = 10,
                },
                new StockLivre() {
                    LivreId = -2,
                    BibliothequeId = -1,
                    StockAchat = 10,
                    StockLocation = 10,
                },
                new StockLivre() {
                    LivreId = -3,
                    BibliothequeId = -1,
                    StockAchat = 10,
                    StockLocation = 10,
                }
            );
        }
    }
}
