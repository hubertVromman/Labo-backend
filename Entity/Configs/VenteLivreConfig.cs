using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class VenteLivreConfig : IEntityTypeConfiguration<VenteLivre> {
        public void Configure(EntityTypeBuilder<VenteLivre> builder) {
            builder.HasKey(vl => new { vl.VenteId, vl.LivreId });

            builder.Property(vl => vl.PrixVente)
                .IsRequired()
                .HasColumnType("DECIMAL(9, 2)");

            builder
                .HasOne(vl => vl.Vente)
                .WithMany(v => v.VenteLivre)
                .HasForeignKey(fk => fk.VenteId)
                .HasConstraintName("FK_VenteLivre_Emprunt");

            builder
                .HasOne(vl => vl.Livre)
                .WithMany(l => l.VenteLivre)
                .HasForeignKey(fk => fk.LivreId)
                .HasConstraintName("FK_VenteLivre_Livre");
        }
    }
}
