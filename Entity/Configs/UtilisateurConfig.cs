using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Configs {
    internal class UtilisateurConfig : IEntityTypeConfiguration<Utilisateur> {
        public void Configure(EntityTypeBuilder<Utilisateur> builder) {
            builder.HasKey(u => u.UtilisateurId);

            builder.Property(nameof(Utilisateur.UtilisateurId))
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(nameof(Utilisateur.Email))
                .IsRequired()
                .HasMaxLength(320);
            builder.Property(nameof(Utilisateur.MotDePasse))
                .IsRequired()
                .HasMaxLength(320);
            builder.Property(nameof(Utilisateur.Nom))
               .IsRequired()
               .HasMaxLength(320);
            builder.Property(nameof(Utilisateur.Prenom))
               .IsRequired()
               .HasMaxLength(320);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasData(
                new Utilisateur() {
                    UtilisateurId = -1,
                    Email = "hello@gmail.com",
                    MotDePasse = "3aJ7NUldI5y7r3eiOP2BEC87BGaV41jrDL4E8/wWydFgSYVEhPbI2WalHlfEdXXHzxVtBQYnkK/J/tCaAizsbg==",
                    Nom = "Noel",
                    Prenom = "Benjamin",
                    Role = "Admin"
                }
            );
        }
    }
}
