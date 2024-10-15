using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class VenteConfig : IEntityTypeConfiguration<Vente> {
        public void Configure(EntityTypeBuilder<Vente> builder) {
            builder.HasKey(v => v.VenteId);

            builder.Property(nameof(Vente.VenteId))
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .HasOne(v => v.Acheteur)
                .WithMany(u => u.Achats)
                .HasForeignKey(fk => fk.AcheteurId)
                .HasConstraintName("FK_Vente_Utilisateur");

            builder
                .HasOne(v => v.Bibliotheque)
                .WithMany(b => b.Ventes)
                .HasForeignKey(fk => fk.BibliothequeId)
                .HasConstraintName("FK_Vente_Bibliotheque");
        }
    }
}