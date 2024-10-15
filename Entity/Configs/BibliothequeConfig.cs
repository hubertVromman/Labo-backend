using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class BibliothequeConfig : IEntityTypeConfiguration<Bibliotheque> {
        public void Configure(EntityTypeBuilder<Bibliotheque> builder) {
            builder.HasKey(b => b.BibliothequeId);

            builder.Property(nameof(Bibliotheque.BibliothequeId))
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(nameof(Bibliotheque.Nom))
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(nameof(Bibliotheque.Adresse))
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(nameof(Bibliotheque.NumeroTelephone))
                .HasMaxLength(50);

            builder.HasData(
                new Bibliotheque() {
                    BibliothequeId = -1,
                    Nom = "Librairie Georges",
                    Adresse = "Rue du Paradis, 5 1400 Nivelles",
                    NumeroTelephone = "+32 68 36 72 98"
                }
            );
        }
    }
}