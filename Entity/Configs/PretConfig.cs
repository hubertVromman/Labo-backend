using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class PretConfig : IEntityTypeConfiguration<Pret> {
        public void Configure(EntityTypeBuilder<Pret> builder) {
            builder.HasKey(e => e.PretId);

            builder.Property(nameof(Pret.PretId))
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .HasOne(e => e.Emprunteur)
                .WithMany(u => u.Emprunts)
                .HasForeignKey(fk => fk.EmprunteurId)
                .HasConstraintName("FK_Pret_Utilisateur");
            builder
                .HasOne(e => e.Bibliotheque)
                .WithMany(b => b.Prets)
                .HasForeignKey(fk => fk.BibliothequeId)
                .HasConstraintName("FK_Pret_Bibliotheque");
        }
    }
}