using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class AuteurConfig : IEntityTypeConfiguration<Auteur> {
        public void Configure(EntityTypeBuilder<Auteur> builder) {
            builder.HasKey(a => a.AuteurId);

            builder.Property(nameof(Auteur.AuteurId))
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(nameof(Auteur.Prenom))
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(nameof(Auteur.Nom))
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new Auteur() {
                    AuteurId = -1,
                    Nom = "Durant",
                    Prenom = "Pierre",
                },
                new Auteur() {
                    AuteurId = -2,
                    Nom = "Nothomb",
                    Prenom = "Amelie",
                }
            );
        }
    }
}