using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class LivreAuteurConfig : IEntityTypeConfiguration<LivreAuteur> {
        public void Configure(EntityTypeBuilder<LivreAuteur> builder) {
            builder.HasKey(la => new { la.LivreId, la.AuteurId });

            builder
                .HasOne(la => la.Auteur)
                .WithMany(a => a.LivreAuteur)
                .HasForeignKey(fk => fk.AuteurId)
                .HasConstraintName("FK_LivreAuteur_Auteur");

            builder
                .HasOne(la => la.Livre)
                .WithMany(l => l.LivreAuteur)
                .HasForeignKey(fk => fk.LivreId)
                .HasConstraintName("FK_LivreAuteur_Livre");

            builder.HasData(
                new LivreAuteur() {
                    LivreId = -1,
                    AuteurId = -1,
                },
                new LivreAuteur() {
                    LivreId = -2,
                    AuteurId = -1,
                },
                new LivreAuteur() {
                    LivreId = -3,
                    AuteurId = -1,
                }
            );
        }
    }
}
